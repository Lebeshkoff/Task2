using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using CargoTransportLib.Trailers;
using Serializer;

namespace CargoTransportLib.Trucks
{
    public abstract class Truck : ISerializer
    {
        public Semitrailer Semitrailer { get; private set; }
        public double Сonsumption { get; private set; }
        public static int Power { get; protected set; }

        public void UpdateConsumption()
        {
            Сonsumption = Power * 0.01 + Semitrailer.Weight * 0.01;
        }

        public void HookTrailer(Semitrailer trailer)
        {
            Semitrailer = trailer;
            UpdateConsumption();
        }

        public Semitrailer UnHookTrailer()
        {
            var result = Semitrailer;
            Semitrailer = null;
            UpdateConsumption();
            return result;
        }

        public abstract void Serialize(XmlWriter xmlWriter);
        public abstract object Deserialize();
    }
}
