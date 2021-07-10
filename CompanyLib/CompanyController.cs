using System;
using System.Collections.Generic;
using CargoTransportLib.Trucks;
using CargoTransportLib.Trailers;
namespace CompanyLib
{
    public static class CompanyController
    {
        public static List<Truck> trucks;
        public static List<Semitrailer> semitrailers;

        public static List<Truck> GetTrucks()
        {
            return trucks;
        }

        public static List<T> GetTrailer<T>()
            where T : Semitrailer
        {
            var results = new List<T>();
            foreach (var semitrailer in semitrailers)
            {
                if(semitrailer is T result)
                {
                    results.Add(result);
                }
            }
            return results;
        }

        public static List<T> GetSameTrailer<T>(int carrying)
            where T : Semitrailer
        {
            var results = GetTrailer<T>();
            return results.FindAll(x => x.carrying == carrying);            
        }
    }
}
