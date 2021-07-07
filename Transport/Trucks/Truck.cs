using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CargoTransportLib.Trailers;

namespace CargoTransportLib.Trucks
{
    public abstract class Truck
    {
        public delegate void ConsumptionHandler();
        public Semitrailer Semitrailer { get; set; }
        public double Сonsumption { get; set; }
        public int Power { get; protected set; }

        private void UpdateConsumption()
        {
            this.Сonsumption = Power * 0.01 + Semitrailer.Weight * 0.01;
        }
    }
}
