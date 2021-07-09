using CargoTransportLib.Cargos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoTransportLib.Trailers
{
    public class Tank : ILiquid
    {
        public LiquidType Type { get; set; }
    }
}
