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
    /// <summary>
    /// Class who describes truck
    /// </summary>
    public abstract class Truck : ISerializer
    {
        /// <summary>
        /// Trailer which hook to the truck
        /// </summary>
        public Semitrailer Semitrailer { get; protected set; }
        /// <summary>
        /// Fuel consumption
        /// </summary>
        public double Сonsumption { get; protected set; }
        /// <summary>
        /// Weight whick truck can carry
        /// </summary>
        public int Power { get; protected set; }

        /// <summary>
        /// Updates consumption after adding some cargos on hooked trailer
        /// </summary>
        public void UpdateConsumption()
        {
            Сonsumption = Power * 0.01 + Semitrailer.Weight * 0.01;
        }

        /// <summary>
        /// Hook trailer to the truck
        /// </summary>
        /// <param name="trailer">Trailer</param>
        public void HookTrailer(Semitrailer trailer)
        {
            if (Semitrailer == null)
            {
                Semitrailer = trailer;
                UpdateConsumption();
            }
            else throw new Exception("Trailer alredy hitched");
        }

        /// <summary>
        /// Un hook trailer
        /// </summary>
        /// <returns>Deatached trailer</returns>
        public Semitrailer UnHookTrailer()
        {
            if (Semitrailer != null)
            {
                var result = Semitrailer;
                Semitrailer = null;
                UpdateConsumption();
                return result;
            }
            else throw new Exception("Nothing to unhook");
        }

        public abstract void Serialize(XmlWriter xmlWriter);
        public abstract void Deserialize(XmlReader xmlReader);
    }
}
