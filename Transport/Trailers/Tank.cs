using CargoTransportLib.Cargos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace CargoTransportLib.Trailers
{
    public class Tank : Semitrailer, ILiquid
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
                if (xmlReader.NodeType != XmlNodeType.EndElement)
                {
                    if (xmlReader.Name == "Liquid")
                    {
                        var liquid = new Liquid();
                        liquid.Deserialize(xmlReader);
                        cargos.Add(liquid);
                    }
                    if (xmlReader.Name == "Weight")
                    {
                        xmlReader.Read();
                        Weight = int.Parse(xmlReader.Value);
                    }
                    if (xmlReader.Name == "Carrying")
                    {
                        xmlReader.Read();
                        carrying = int.Parse(xmlReader.Value);
                    }
                }
                if (xmlReader.NodeType == XmlNodeType.EndElement && xmlReader.Name == "Semitrailer")
                {
                    break;
                }
            }
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (obj as Tank == null) return false;
            return Type == ((Tank)obj).Type &&
                Weight == ((Tank)obj).Weight &&
                cargos.Equals(((Tank)obj).cargos) &&
                carrying == ((Tank)obj).carrying;
        }

        public override int GetHashCode()
        {
            return Type.GetHashCode() ^ Weight.GetHashCode() ^ 
                carrying.GetHashCode() ^ cargos.GetHashCode();
        }

        public override string ToString()
        {
            return "Tank {Type: " + Type + "Carrying: " + carrying + " Weight: " + Weight + " }";
        }
    }
}
