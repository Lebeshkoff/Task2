using System;
using CargoTransportLib.Trucks;
using CargoTransportLib.Cargos;
using System.Collections.Generic;

namespace CargoTransportLib.Trailers
{
    public abstract class Semitrailer
    {
        private event Truck.ConsumptionHandler OnChange;
        public readonly int carrying;
        public int Weight { get; private set; }
        public List<Cargo> cargos;
        public void LoadCargo(Cargo cargo)
        {
            if(!CheckTypes(cargo))
            {
                throw new Exception("The cargos are not compatible by type or storage conditions with those already loaded");
            }
            else
            {
                cargos.Add(cargo);
                Weight += cargo.Weight;
                OnChange();
            }
        }
        public void UnloadCargo(Cargo cargo)
        {
            if (cargos.Exists(x => x == cargo))
            {
                cargos.Remove(cargo);
                Weight -= cargo.Weight;
                OnChange();
            }
            else
            {
                throw new Exception("You are trying to delete a missing cargo");
            }
        }
        protected abstract bool CheckTypes(Cargo cargos);
        
    }
}
