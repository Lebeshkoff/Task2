﻿using Serializer;
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
                        Сonsumption = double.Parse(xmlReader.Value.Replace(".",","));
                    }
                    if (xmlReader.Name == "Power")
                    {
                        xmlReader.Read();
                        Power = int.Parse(xmlReader.Value);
                    }
                }
                if(xmlReader.NodeType == XmlNodeType.EndElement && xmlReader.Name == "Truck")
                {
                    break;
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
