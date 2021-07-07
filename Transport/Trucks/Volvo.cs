using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CargoTransportLib.Trailers;

namespace CargoTransportLib.Trucks
{
    public class Volvo : Truck
    {
        public Volvo(Semitrailer semitrailer, int power)
        {
            this.Power = power;
            this.Semitrailer = semitrailer;
            this.Сonsumption = semitrailer.Weight * 0.01;
        }
    }
}
