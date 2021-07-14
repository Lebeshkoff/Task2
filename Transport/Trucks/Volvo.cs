using Serializer;
using System.Linq;
using System.Xml;

namespace CargoTransportLib.Trucks
{
    public class Volvo : Truck, ISerializer
    {
        public Volvo(int power)
        {
            Power = power;
        }

        public override object Deserialize(XmlReader xmlReader)
        {
            throw new System.NotImplementedException();
        }

        public override void Serialize(XmlWriter xmlWriter)
        {
            xmlWriter.WriteStartElement("Truck");
            xmlWriter.WriteAttributeString("Model", GetType().Name);
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
            xmlWriter.WriteEndElement();
        }
    }
}
