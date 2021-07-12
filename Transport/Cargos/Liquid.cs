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

        public override object Deserialize()
        {
            throw new NotImplementedException();
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
    }
}
