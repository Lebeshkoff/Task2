using CargoTransportLib.Cargos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace CargoTransportLib.Trailers
{
    public class Titl : Semitrailer
    {
        public Titl(int carrying)
        {
            this.carrying = carrying;
        }

        public override object Deserialize()
        {
            throw new NotImplementedException();
        }

        public override void LoadCargo(Cargo cargo)
        {
            if(cargo.StorageTemperature < 30)
            {
                throw new Exception("Use refrigerator for this type of goods");
            }
            base.LoadCargo(cargo);
        }

        public override void Serialize(XmlWriter xmlWriter)
        {
            throw new NotImplementedException();
        }

        protected override bool CheckTypes(Cargo cargos)
        {
            throw new NotImplementedException(); //TODO
        }
    }
}
