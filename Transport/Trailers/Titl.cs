using CargoTransportLib.Cargos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoTransportLib.Trailers
{
    public class Titl : Semitrailer
    {
        public Titl(int carrying)
        {
            this.carrying = carrying;
        }
        public override void LoadCargo(Cargo cargo)
        {
            //TODO
            base.LoadCargo(cargo);
        }
        protected override bool CheckTypes(Cargo cargos)
        {
            throw new NotImplementedException(); //TODO
        }
    }
}
