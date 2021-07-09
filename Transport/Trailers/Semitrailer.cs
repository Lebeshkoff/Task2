using System;
using CargoTransportLib.Trucks;

namespace CargoTransportLib.Trailers
{
    public abstract class Semitrailer
    {
        event Truck.ConsumptionHandler OnChange;
        public readonly int carrying;
        public int Weight { get; }
        public void LoadCargo()
        {
            OnChange();
            //TODO: check type of produsts & change weight
            throw new NotImplementedException();
        }
        public void UnloadCargo()
        {
            OnChange();
            throw new NotImplementedException();
        }
        
    }
}
