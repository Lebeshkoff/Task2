using CargoTransportLib.Cargos;
using System;
using Serializer;
using System.Xml;

namespace CargoTransportLib.Trailers
{
    public class Refrigerator : Semitrailer , IChilled
    {
        public int Temperature { get; set; }
        public GoodsType Type { get; set; }

        public Refrigerator(int carrying = 0)
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
            return true;
            //throw new NotImplementedException(); //TODO
        }

        public override void Serialize(XmlWriter xmlWriter)
        {
            xmlWriter.WriteStartElement("Semitrailer");
            xmlWriter.WriteAttributeString("Type", GetType().Name);
            xmlWriter.WriteStartElement("Temperature");
            xmlWriter.WriteValue(Temperature);
            xmlWriter.WriteEndElement();
            xmlWriter.WriteStartElement("Weight");
            xmlWriter.WriteValue(Weight);
            xmlWriter.WriteEndElement();
            xmlWriter.WriteStartElement("Carrying");
            xmlWriter.WriteValue(carrying);
            xmlWriter.WriteEndElement();
            xmlWriter.WriteStartElement("Cargos");
            foreach (var cargo in cargos)
            {
                cargo.Serialize(xmlWriter);
            }
            xmlWriter.WriteEndElement();
            xmlWriter.WriteEndElement();
        }

        public override void Deserialize(XmlReader xmlReader)
        {
            throw new NotImplementedException();
        }
    }
}
