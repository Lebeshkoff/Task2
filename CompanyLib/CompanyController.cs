using System;
using System.Collections.Generic;
using CargoTransportLib.Trucks;
using CargoTransportLib.Trailers;
using CargoTransportLib.Cargos;
using Serializer;
using System.Xml;

namespace CompanyLib
{
    public class CompanyController : ISerializer
    {
        public List<Truck> trucks = new List<Truck>();
        public List<Semitrailer> semitrailers = new List<Semitrailer>();

        public CompanyController() { }

        public static void LoadTrailerWithTruck(Truck truck, Cargo cargo)
        {
            truck.Semitrailer.LoadCargo(cargo);
            truck.UpdateConsumption();
        }

        public List<Truck> GetTrucks()
        {
            return trucks;
        }

        public List<T> GetTrailer<T>()
            where T : Semitrailer
        {
            var results = new List<T>();
            foreach (var semitrailer in semitrailers)
            {
                if (semitrailer is T result)
                {
                    results.Add(result);
                }
            }
            return results;
        }

        public List<T> GetSameTrailer<T>(int carrying)
            where T : Semitrailer
        {
            var results = GetTrailer<T>();
            return results.FindAll(x => x.carrying == carrying);
        }

        public List<Truck> GetTrucksWithTrailerByTypeOfCargos<T>()
        {
            var results = new List<Truck>();
            foreach (var truck in trucks)
            {
                if (truck.Semitrailer != null && truck.Semitrailer.cargos[0] is T)
                {
                    results.Add(truck);
                }
            }
            return results;
        }

        public List<Truck> GetTrucksWithTrailerWhoMayLoad()
        {
            var results = new List<Truck>();
            foreach (var truck in trucks)
            {
                if (truck.Semitrailer != null && truck.Semitrailer.carrying - truck.Semitrailer.Weight > 0)
                {
                    results.Add(truck);
                }
            }
            return results;
        }

        public List<Truck> GetTrucksWithEmptyTrailer()
        {
            var results = new List<Truck>();
            foreach (var truck in trucks)
            {
                if (truck.Semitrailer != null && truck.Semitrailer.cargos.Count == 0)
                {
                    results.Add(truck);
                }
            }
            return results;
        }

        public void Serialize(XmlWriter xmlWriter)
        {
            xmlWriter.WriteStartElement("Company");
            xmlWriter.WriteStartElement("Trucks");
            foreach (var truck in trucks)
            {
                truck.Serialize(xmlWriter);
            }
            xmlWriter.WriteEndElement();
            xmlWriter.WriteStartElement("Semitrailers");
            foreach (var semitrailer in semitrailers)
            {
                semitrailer.Serialize(xmlWriter);
            }
            xmlWriter.WriteEndElement();
            xmlWriter.WriteEndElement();
        }

        public void Deserialize(XmlReader xmlReader)
        {
            while (xmlReader.Read())
            {
                if (xmlReader.NodeType != XmlNodeType.EndElement)
                {
                    if (xmlReader.Name == "Trucks")
                    {
                        xmlReader.Read();
                        while (xmlReader.NodeType != XmlNodeType.EndElement && xmlReader.Name != "Trucks")
                        {
                            if (xmlReader.Name == "Truck")
                            {
                                switch (xmlReader.GetAttribute(0))
                                {
                                    case "Volvo":
                                        var volvo = new Volvo();
                                        volvo.Deserialize(xmlReader);
                                        trucks.Add(volvo);
                                        break;

                                    case "Scania":
                                        var scania = new Scania();
                                        scania.Deserialize(xmlReader);
                                        trucks.Add(scania);
                                        break;
                                }
                            }
                        }
                    }
                    if (xmlReader.Name == "Semitrailers")
                    {
                        xmlReader.Read();
                        while (xmlReader.NodeType != XmlNodeType.EndElement && xmlReader.Name != "Semitrailers")
                        {
                            if (xmlReader.Name == "Semitrailer")
                            {
                                switch (xmlReader.GetAttribute(0))
                                {
                                    case "Refrigerator":
                                        var refrigerator = new Refrigerator();
                                        refrigerator.Deserialize(xmlReader);
                                        semitrailers.Add(refrigerator);
                                        break;

                                    case "Tank":
                                        var tank = new Tank();
                                        tank.Deserialize(xmlReader);
                                        semitrailers.Add(tank);
                                        break;
                                }
                            }
                        }
                        //semitrailers.Add((Semitrailer)XMLDeserializer.DeserialiseObject("", xmlReader));
                    }
                }
            }
        }
    }
}
