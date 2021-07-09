using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoTransportLib.Cargos
{
    public class Liquid : Cargo
    {
        public LiquidType type;

        public Liquid(LiquidType type, int weight)
        {
            Weight = weight;
            this.type = type;
        }
    }
}
