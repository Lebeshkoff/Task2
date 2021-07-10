using CargoTransportLib.Cargos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoTransportLib.Trailers
{
    public class Refrigerator : IChilled
    {
        public int Temperature { get; set; }
        public GoodsType Type { get; set; }
    }
}
