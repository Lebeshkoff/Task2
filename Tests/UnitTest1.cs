using System;
using Xunit;
using CargoTransportLib.Cargos;
using CargoTransportLib.Trailers;
using CargoTransportLib.Trucks;
using CompanyLib;
using Serializer;
using Deserializer;

namespace Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var xml = new XMLSerializer("xml.xml");
            var truck = new Volvo(220);
            var trailer = new Refrigerator(200);
            var goods = new Goods(GoodsType.Eat, -12, 10, "Fish");
            var goods1 = new Goods(GoodsType.Eat, -12, 100, "Fish");
            var goods2 = new Goods(GoodsType.Eat, -12, 5, "Ice");
            trailer.LoadCargo(goods);
            trailer.LoadCargo(goods1);
            trailer.LoadCargo(goods2);
            truck.HookTrailer(trailer);
            var com = new CompanyController();
            com.semitrailers.Add(trailer);
            com.trucks.Add(truck);
            xml.Serialize(com);
            var f = XMLDeserializer.DeserialiseObject("xml.xml");
            if(!com.Equals(f))
            {
                throw new Exception("f");
            }
        }
    }
}
