using Serializer;
using System.Linq;
using System.Xml;

namespace CargoTransportLib.Trucks
{
    public class Scania : Truck
    {
        public Scania(int power)
        {
            Power = power;
        }

        public override object Deserialize()
        {
            throw new System.NotImplementedException();
        }

        public override void Serialize(XmlWriter xmlWriter)
        {
            xmlWriter.WriteStartElement("Truck");
            xmlWriter.WriteAttributeString("Model", GetType().Name);
            xmlWriter.WriteEndAttribute();
            if (typeof(ISerializer) == Semitrailer.GetType().GetInterfaces().ToList().Find(x => x == typeof(ISerializer)))
            {
                Semitrailer.Serialize(xmlWriter);
            }
            xmlWriter.WriteStartElement("Consumption");
            xmlWriter.WriteValue(Сonsumption);
            xmlWriter.WriteEndElement();
            xmlWriter.WriteStartElement("Power");
            xmlWriter.WriteValue(Power);
            xmlWriter.WriteEndElement();
        }
    }
}
