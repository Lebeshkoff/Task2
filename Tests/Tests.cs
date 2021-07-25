using System;
using Xunit;
using CargoTransportLib.Cargos;
using CargoTransportLib.Trailers;
using CargoTransportLib.Trucks;
using CompanyLib;
using Serializer;
using Deserializer;
using System.Collections.Generic;

namespace Tests
{
    public class Tests
    {
        public static IEnumerable<object[]> GetGoodsData()
        {
            var testData = new List<object[]>
        {
            new object[] { GoodsType.Eat, -12, 100, "Fish" },
            new object[] { GoodsType.Eat, -20, 200, "Ice" },
            new object[] { GoodsType.Eat, -18, 1, "Meat" },
            new object[] { GoodsType.Chemistry, 0, 100, "Chlore" },
            new object[] { GoodsType.Chemistry, 5, 90, "Efir" },
            new object[] { GoodsType.Technique, 20, 200, "CPU" },
            new object[] { GoodsType.Eat, -18, 100, "Meat" },
            new object[] { GoodsType.Technique, 20, 100, "Displays" },
            new object[] { GoodsType.Chemistry, 0, 100, "Poliefir" },
        };

            return testData;
        }
        [Theory]
        [MemberData(nameof(GetGoodsData))]
        public void TestLoadToTrailer(GoodsType type, int storageTemperature, int weight, string name)
        {
            var trailer = new Refrigerator(200);
            var goods = new Goods(type, storageTemperature, weight, name);
            trailer.LoadCargo(goods);

            Assert.Equal(goods, trailer.cargos[0]);
        }

        [Theory]
        [MemberData(nameof(GetGoodsData))]
        public void TestUnLoadToTrailer(GoodsType type, int storageTemperature, int weight, string name)
        {
            var trailer = new Refrigerator(200);
            var goods = new Goods(type, storageTemperature, weight, name);
            trailer.LoadCargo(goods);
            trailer.UnloadCargo(goods);

            Assert.True(trailer.cargos.Count == 0);
        }

        [Theory]
        [MemberData(nameof(GetGoodsData))]
        public void TestLoadToTruckWithTrailer(GoodsType type, int storageTemperature, int weight, string name)
        {
            var truck = new Volvo(1000);
            truck.HookTrailer(new Refrigerator(200));
            var goods = new Goods(type, storageTemperature, weight, name);
            CompanyController.LoadTrailerWithTruck(truck, goods);

            Assert.Equal(truck.Semitrailer.cargos[0], goods);
        }
    }
}
