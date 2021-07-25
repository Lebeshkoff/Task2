using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Serializer;

namespace CargoTransportLib.Cargos
{
    /// <summary>
    /// Class who describes cargo
    /// </summary>
    public abstract class Cargo : ISerializer
    {
        /// <summary>
        /// Weight of cargo
        /// </summary>
        public int Weight { get; protected set; }
        /// <summary>
        /// Storage temperature
        /// </summary>
        public int StorageTemperature { get; protected set; }

        public abstract void Deserialize(XmlReader xmlReader);
        public abstract void Serialize(XmlWriter xmlWriter);
    }
}
