using System;
using System.Collections.Generic;
using CargoTransportLib.Trucks;
using CargoTransportLib.Trailers;
using CargoTransportLib.Cargos;
using Serializer;
using System.Xml;

namespace CompanyLib
{
    /// <summary>
    /// Class who controll all operations with trailers and truck
    /// </summary>
    public class CompanyController : ISerializer
    {
        /// <summary>
        /// Trucks
        /// </summary>
        public List<Truck> trucks = new List<Truck>();
        /// <summary>
        /// Semitrailers
        /// </summary>
        public List<Semitrailer> semitrailers = new List<Semitrailer>();

        public CompanyController() { }

        /// <summary>
        /// Loaв trailer which the trailer is attached
        /// </summary>
        /// <param name="truck">Truck</param>
        /// <param name="cargo">Cargo</param>
        public static void LoadTrailerWithTruck(Truck truck, Cargo cargo)
        {
            if (truck.Semitrailer != null)
            {
                truck.Semitrailer.LoadCargo(cargo);
                truck.UpdateConsumption();
            }
            else throw new Exception("Truck without trailer");
        }

        /// <summary>
        /// Get list of truck
        /// </summary>
        /// <returns>Returns list of trucks</returns>
        public List<Truck> GetTrucks()
        {
            return trucks;
        }

        /// <summary>
        /// Getting trailers of a given type
        /// </summary>
        /// <typeparam name="T">Ензу</typeparam>
        /// <returns>Еrailers of a given type</returns>
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

        /// <summary>
        /// Getting the same trailers
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="carrying">Carrying</param>
        /// <returns>List of same trailer</returns>
        public List<T> GetSameTrailer<T>(int carrying)
            where T : Semitrailer
        {
            var results = GetTrailer<T>();
            return results.FindAll(x => x.carrying == carrying);
        }

        /// <summary>
        /// Receiving trucks with trailers in which the same type of cargo
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
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

        /// <summary>
        /// Receiving trucks with trailers that can be loaded
        /// </summary>
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

        /// <summary>
        /// Receiving trucks with trailers that empty
        /// </summary>
        /// <returns></returns>
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
                    }
                }
            }
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (obj as CompanyController == null) return false;
            return trucks.Equals(((CompanyController)obj).trucks) &&
                semitrailers.Equals(((CompanyController)obj).semitrailers);
        }

        public override int GetHashCode()
        {
            return semitrailers.GetHashCode() ^ trucks.GetHashCode();
        }

        public override string ToString()
        {
            string truckStr = "";
            string semitrailerStr = "";
            foreach (var truck in trucks)
            {
                truckStr += truck + "\n";
            }
            foreach (var semitrailer in semitrailers)
            {
                semitrailerStr += semitrailer + "\n";
            }
            return "Company {Semitrailers: " + semitrailerStr + " Trucks: " + truckStr + " }";
        }
    }
}
