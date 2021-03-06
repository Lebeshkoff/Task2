using Serializer;
using System.Linq;
using System.Xml;
using CargoTransportLib.Trailers;

namespace CargoTransportLib.Trucks
{
    /// <summary>
    /// Scania truck
    /// </summary>
    public class Scania : Truck
    {
        /// <summary>
        /// Create new scania truck
        /// </summary>
        /// <param name="power">Weight whick truck can carry</param>
        public Scania(int power = 0)
        {
            Power = power;
        }

        public override void Deserialize(XmlReader xmlReader)
        {
            while (xmlReader.Read())
            {
                if (xmlReader.NodeType != XmlNodeType.EndElement)
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

                        }
                    }
                    if (xmlReader.Name == "Consumption")
                    {
                        xmlReader.Read();
                        Сonsumption = double.Parse(xmlReader.Value.Replace(".", ","));
                    }
                    if (xmlReader.Name == "Power")
                    {
                        xmlReader.Read();
                        Power = int.Parse(xmlReader.Value);
                    }
                }
                if (xmlReader.NodeType == XmlNodeType.EndElement && xmlReader.Name == "Truck")
                {
                    break;
                }
            }
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
            xmlWriter.WriteEndElement();
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (obj as Scania == null) return false;
            return Semitrailer == ((Scania)obj).Semitrailer &&
                Сonsumption == ((Scania)obj).Сonsumption &&
                Power == ((Scania)obj).Power;
        }

        public override int GetHashCode()
        {
            return Semitrailer.GetHashCode() ^ Сonsumption.GetHashCode() ^
                Power.GetHashCode();
        }

        public override string ToString()
        {
            return "Scania {Semitrailer: " + Semitrailer + " Сonsumption: " + Сonsumption + "Power: " + Power + " }";
        }
    }
}
