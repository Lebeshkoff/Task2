using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CargoTransportLib.Trailers;

namespace CargoTransportLib.Trucks
{
    public class Scania : Truck
    {
        public Scania(int power)
        {
            Power = power;
        }
    }
}
