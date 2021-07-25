using System;
using System.Xml;
using CargoTransportLib.Trucks;
using CargoTransportLib.Trailers;
using System.Collections.Generic;
using CompanyLib;

namespace Deserializer
{
    public static class XMLDeserializer
    {
        public static object DeserialiseObject(string path, XmlReader xmlReader = null)
        {
            if (xmlReader == null)
            {
                xmlReader = XmlReader.Create(path);
            }            
            while (xmlReader.Read())
            {
                if(xmlReader.Name == "Company")
                {
                    var company = new CompanyController();
                    company.Deserialize(xmlReader);
                    return company;
                }
                if (xmlReader.Name == "Truck")
                {
                    switch (xmlReader.GetAttribute(0))
                    {
                        case "Volvo":
                            var volvo = new Volvo();
                            volvo.Deserialize(xmlReader);
                            return volvo;

                        case "Scania":
                            var scania = new Scania();
                            scania.Deserialize(xmlReader);
                            return scania;
                    }

                }
                if(xmlReader.Name == "Semitrailer")
                {
                    switch (xmlReader.GetAttribute(0))
                    {
                        case "Refrigerator":
                            var refrigerator = new Refrigerator();
                            refrigerator.Deserialize(xmlReader);
                            return refrigerator;

                        case "Tank":
                            var tank = new Tank();
                            tank.Deserialize(xmlReader);
                            return tank;
                    }
                }
            }
            throw new Exception("Not supported node");
        }

        public static List<object> DeserializeList(string path)
        {
            var xmlReader = XmlReader.Create(path);
            var result = new List<object>();
            while (xmlReader.Read())
            {
                if(xmlReader.Name == "Trucks")
                {
                    result.Add(DeserialiseObject(path, xmlReader));
                }
            }
                DeserialiseObject(path, xmlReader);
                throw new Exception("Not supported lists");
        }
    }
}