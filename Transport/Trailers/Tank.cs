using CargoTransportLib.Cargos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace CargoTransportLib.Trailers
{
    public class Tank : Semitrailer , ILiquid
    {
        public LiquidType Type { get; set; }

        public Tank(int carrying = 0)
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

        public override void Serialize(XmlWriter xmlWriter)
        {
            xmlWriter.WriteStartElement("Semitrailer");
            xmlWriter.WriteAttributeString("Type", GetType().Name);
            xmlWriter.WriteStartElement("Weight");
            xmlWriter.WriteValue(Weight);
            xmlWriter.WriteEndElement();
            xmlWriter.WriteStartElement("Carrying");
            xmlWriter.WriteValue(carrying);
            xmlWriter.WriteEndElement();
            xmlWriter.WriteStartElement("Cargo");
            cargos[0].Serialize(xmlWriter);
            xmlWriter.WriteEndElement();
            xmlWriter.WriteEndElement();
        }

        public override void Deserialize(XmlReader xmlReader)
        {
            while (xmlReader.Read())
            {
                if (xmlReader.Name == "Liquid")
                {
                    var liquid = new Liquid();
                    liquid.Deserialize(xmlReader);
                    cargos.Add(liquid);
                }
                if (xmlReader.Name == "Weight")
                {
                    Weight = int.Parse(xmlReader.Value);
                }
                if (xmlReader.Name == "Carrying")
                {
                    carrying = int.Parse(xmlReader.Value);
                }
                if (xmlReader.NodeType == XmlNodeType.EndElement && xmlReader.Name == "Semitrailer")
                {
                    break;
                }
            }
        }
    }
}
