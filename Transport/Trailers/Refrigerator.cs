using CargoTransportLib.Cargos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoTransportLib.Trailers
{
    public class Refrigerator : Semitrailer , IChilled
    {
        public int Temperature { get; set; }
        public GoodsType Type { get; set; }

        public Refrigerator(int carrying)
        {
            this.carrying = carrying;
        }

        public override void LoadCargo(Cargo cargo)
        {
            if(cargos.Count == 0 && cargo is Goods)
            {
                Temperature = cargo.StorageTemperature;
                Type = ((Goods)cargo).type;
            }
            base.LoadCargo(cargo);
        }

        protected override bool CheckTypes(Cargo cargos)
        {
            throw new NotImplementedException(); //TODO
        }
    }
}
