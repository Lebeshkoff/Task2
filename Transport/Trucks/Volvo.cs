using Serializer;
using System.Linq;
using System.Xml;
using CargoTransportLib.Trailers;

namespace CargoTransportLib.Trucks
{
    public class Volvo : Truck
    {
        public Volvo(int power = 0)
        {
            Power = power;
        }

        public override void Deserialize(XmlReader xmlReader)
        {
            while (xmlReader.Read())
            {
                if (xmlReader.Name == "Semitrailer")
                {
                    switch (xmlReader.GetAttribute(0))
                    {
                        case "Refrigerator":
                            Semitrailer = new Refrigerator();
                            Semitrailer.Deserialize(xmlReader);
                            break;

                        case "Tank":
                            Semitrailer = new Tank();
                            Semitrailer.Deserialize(xmlReader);
                            break;

                        case "Tilt":
                            Semitrailer = new Titl();
                            Semitrailer.Deserialize(xmlReader);
                            break;

                        default: 
                            break;
                    }
                }
                if(xmlReader.Name == "Consumption")
                {
                    Сonsumption = double.Parse(xmlReader.Value);
                }
                if(xmlReader.Name == "Power")
                {
                    Power = int.Parse(xmlReader.Value);
                }
            }
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
