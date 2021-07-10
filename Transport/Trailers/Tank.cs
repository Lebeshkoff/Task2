using CargoTransportLib.Cargos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoTransportLib.Trailers
{
    public class Tank : Semitrailer , ILiquid
    {
        public LiquidType Type { get; set; }

        public Tank(int carrying)
        {
            this.carrying = carrying;
        }
        public override void LoadCargo(Cargo cargo)
        {
            if (cargos.Count == 0 && cargo is Liquid)
            {
                Type = ((Liquid)cargo).type;
            }
            base.LoadCargo(cargo);
        }
        protected override bool CheckTypes(Cargo cargos)
        {
            //todo
            throw new NotImplementedException();
        }
    }
}
