using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace CargoTransportLib.Cargos
{
    public class Liquid : Cargo
    {
        public LiquidType type;

        public Liquid(LiquidType type, int weight)
        {
            Weight = weight;
            this.type = type;
        }
        public Liquid() { }

        public override void Deserialize(XmlReader xmlReader)
        {
            while (xmlReader.Read())
            {
                if (xmlReader.NodeType != XmlNodeType.EndElement)
                {
                    if (xmlReader.Name == "Type")
                    {
                        xmlReader.Read();
                        switch (xmlReader.Value)
                        {
                            case "Oil":
                                type = LiquidType.Oil;
                                break;
                            case "Petrol92":
                                type = LiquidType.Petrol92;
                                break;
                            case "Petrol95":
                                type = LiquidType.Petrol95;
                                break;
                            case "Petrol100":
                                type = LiquidType.Petrol100;
                                break;
                            case "PetrolE85":
                                type = LiquidType.PetrolE85;
                                break;
                            case "Diesel":
                                type = LiquidType.Diesel;
                                break;
                        }
                    }
                    if (xmlReader.Name == "Weight")
                    {
                        xmlReader.Read();
                        Weight = int.Parse(xmlReader.Value);
                    }
                }
                if (xmlReader.NodeType == XmlNodeType.EndElement && xmlReader.Name == "Liquid")
                {
                    break;
                }
            }
        }

        public override void Serialize(XmlWriter xmlWriter)
        {
            xmlWriter.WriteStartElement("Liquid");
            xmlWriter.WriteStartElement("Type");
            xmlWriter.WriteValue(type.ToString());
            xmlWriter.WriteEndElement();
            xmlWriter.WriteStartElement("Weight");
            xmlWriter.WriteValue(Weight);
            xmlWriter.WriteEndElement();
            xmlWriter.WriteEndElement();
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (obj as Liquid == null) return false;
            return type == ((Liquid)obj).type &&
                Weight == ((Liquid)obj).Weight;
        }

        public override int GetHashCode()
        {
            return type.GetHashCode() ^ Weight.GetHashCode();
        }

        public override string ToString()
        {
            return "Goods {Type: " + type + " Weight: " + Weight + " }";
        }
    }
}
