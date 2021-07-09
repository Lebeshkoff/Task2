using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoTransportLib.Cargos
{
    public class Goods : Cargo
    {
        public GoodsType type;
        public string name;
        public Goods(GoodsType type, int storageTemperature, int weight, string name )
        {
            this.type = type;
            StorageTemperature = storageTemperature;
            Weight = weight;
            this.name = name;
        }
    }
}
