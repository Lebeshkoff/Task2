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
            var goods1 = new Goods(GoodsType.Eat, -12, 100, "Fish");
            var goods2 = new Goods(GoodsType.Eat, -12, 5, "Ice");
            trailer.LoadCargo(goods);
            trailer.LoadCargo(goods1);
            //trailer.LoadCargo(goods2);
            truck.HookTrailer(trailer);
            xml.Serialize(truck);
            xml.Deserialize("xml.xml");
        }
    }
}
