using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoTransportLib.Cargos
{
    public abstract class Cargo
    {
        public int Weight { get; protected set; }
        public int StorageTemperature { get; protected set; }

    }
}
