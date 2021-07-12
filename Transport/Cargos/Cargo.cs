using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Serializer;

namespace CargoTransportLib.Cargos
{
    public abstract class Cargo : ISerializer
    {
        public int Weight { get; protected set; }
        public int StorageTemperature { get; protected set; }

        public abstract object Deserialize();
        public abstract void Serialize(XmlWriter xmlWriter);
    }
}
