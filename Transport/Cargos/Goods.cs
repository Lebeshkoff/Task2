using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

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

        public override object Deserialize()
        {
            throw new NotImplementedException();
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
    }
}
