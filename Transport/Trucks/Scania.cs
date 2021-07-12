using Serializer;
using System.Xml;

namespace CargoTransportLib.Trucks
{
    public class Scania : Truck , ISerializer
    {
        public Scania(int power)
        {
            Power = power;
        }

        public object Deserialize()
        {
            throw new System.NotImplementedException();
        }

        public void Serialize(XmlWriter xmlWriter)
        {
            xmlWriter.WriteStartElement("Truck");
            xmlWriter.WriteAttributeString("Model", GetType().Name);
            xmlWriter.WriteEndAttribute();
            if (typeof(ISerializer).IsAssignableTo(Semitrailer.GetType()))
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
