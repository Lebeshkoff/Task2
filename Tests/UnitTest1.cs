using System;
using Xunit;
using CargoTransportLib.Cargos;
using CargoTransportLib.Trailers;
using CargoTransportLib.Trucks;
using CompanyLib;
using Serializer;

namespace Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var xml = new XMLHandler("xml.xml");
            var truck = new Volvo(220);
            var trailer = new Refrigerator(200);
            var goods = new Goods(GoodsType.Eat, -12, 10, "Fish");
            trailer.LoadCargo(goods);
            truck.HookTrailer(trailer);
            xml.Serialize(truck);
        }
    }
}
