using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace CargoTransportLib.Cargos
{
    /// <summary>
    /// Class who describes solid cargos
    /// </summary>
    public class Goods : Cargo
    {
        /// <summary>
        /// Type of goods
        /// </summary>
        public GoodsType type;
        /// <summary>
        /// Name of goods
        /// </summary>
        public string name;
        /// <summary>
        /// Creates goods with given parameters
        /// </summary>
        /// <param name="type">Type of goods</param>
        /// <param name="storageTemperature">Storage temperature</param>
        /// <param name="weight">Weight of goods</param>
        /// <param name="name">Name of goods</param>
        public Goods(GoodsType type, int storageTemperature, int weight, string name)
        {
            this.type = type;
            StorageTemperature = storageTemperature;
            Weight = weight;
            this.name = name;
        }
        public Goods() { }

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
                            case "Eat":
                                type = GoodsType.Eat;
                                break;
                            case "Chemistry":
                                type = GoodsType.Chemistry;
                                break;
                            case "Technique":
                                type = GoodsType.Technique;
                                break;
                        }
                    }
                    if (xmlReader.Name == "Name")
                    {
                        xmlReader.Read();
                        name = xmlReader.Value;
                    }
                    if (xmlReader.Name == "StorageTemperature")
                    {
                        xmlReader.Read();
                        StorageTemperature = int.Parse(xmlReader.Value);
                    }
                    if (xmlReader.Name == "Weight")
                    {
                        xmlReader.Read();
                        Weight = int.Parse(xmlReader.Value);
                    }
                }
                if (xmlReader.NodeType == XmlNodeType.EndElement && xmlReader.Name == "Goods")
                {
                    break;
                }
            }
        }

        public override void Serialize(XmlWriter xmlWriter)
        {
            xmlWriter.WriteStartElement("Goods");
            xmlWriter.WriteStartElement("Type");
            xmlWriter.WriteValue(type.ToString());
            xmlWriter.WriteEndElement();
            xmlWriter.WriteStartElement("StorageTemperature");
            xmlWriter.WriteValue(StorageTemperature);
            xmlWriter.WriteEndElement();
            xmlWriter.WriteStartElement("Weight");
            xmlWriter.WriteValue(Weight);
            xmlWriter.WriteEndElement();
            xmlWriter.WriteStartElement("Name");
            xmlWriter.WriteValue(name);
            xmlWriter.WriteEndElement();
            xmlWriter.WriteEndElement();
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (obj as Goods == null) return false;
            return name == ((Goods)obj).name && 
                type == ((Goods)obj).type && 
                StorageTemperature == ((Goods)obj).StorageTemperature &&
                Weight == ((Goods)obj).Weight;
        }

        public override int GetHashCode()
        {
            return name.GetHashCode() ^ type.GetHashCode() ^ 
                StorageTemperature.GetHashCode() ^ Weight.GetHashCode(); 
        }

        public override string ToString()
        {
            return "Goods {Name: " + name + " Type: " + type + "StorageTemperature: " + StorageTemperature + " Weight: " + Weight + " }";
        }
    }
}
