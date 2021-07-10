using System;
using CargoTransportLib.Trucks;
using CargoTransportLib.Cargos;
using System.Collections.Generic;
using System.ComponentModel;

namespace CargoTransportLib.Trailers
{
    public abstract class Semitrailer
    {
        public int carrying;
        public int Weight { get; private set; }
        public List<Cargo> cargos;

        public virtual void LoadCargo(Cargo cargo)
        {
            if(!CheckTypes(cargo))
            {
                throw new Exception("The cargos are not compatible by type or storage conditions with those already loaded");
            }
            else
            {
                if (cargo is Goods goods)
                {
                    var currentCargo = cargos.Find(x => x is Goods
                    && ((Goods)x).name == goods.name
                    && ((Goods)x).type == goods.type
                    && ((Goods)x).StorageTemperature == goods.StorageTemperature);
                    if (currentCargo.StorageTemperature != cargo.StorageTemperature
                        && goods.type != ((Goods)currentCargo).type)
                    {
                        throw new Exception("Type or temperature does not match.");
                    }
                    cargos.Remove(currentCargo);
                    cargos.Add(new Goods(goods.type, goods.StorageTemperature, goods.Weight + currentCargo.Weight, goods.name));
                }
                if (cargo is Liquid liquid)
                {
                    var currentCargo = cargos.Find(x => x is Liquid
                    && ((Liquid)x).type == liquid.type);
                    if (((Liquid)currentCargo).type != liquid.type)
                    {
                        throw new Exception("The type of liquid does not match.");
                    }
                    cargos.Remove(currentCargo);
                    cargos.Add(new Liquid(liquid.type, liquid.Weight + currentCargo.Weight));
                }
                Weight += cargo.Weight;
            }
        }

        public void UnloadCargo(Cargo cargo)
        {
            if (cargos.Exists(x => x.GetType() == cargo.GetType()))
            {
                var currentCargo = cargos.Find(x => x.GetType() == cargo.GetType());
                if (cargo.Weight <= currentCargo.Weight)
                {
                    cargos.Remove(currentCargo);
                    if (cargo.Weight != currentCargo.Weight)
                    {
                        if (cargo is Liquid liquid)
                        {
                            cargos.Add(new Liquid(liquid.type, currentCargo.Weight - cargo.Weight));
                        }
                        if (cargo is Goods goods)
                        {
                            cargos.Add(new Goods(goods.type,
                                cargo.StorageTemperature,
                                currentCargo.Weight - cargo.Weight,
                                goods.name));
                        }
                    }
                    Weight -= cargo.Weight;
                }
                else
                {
                    throw new Exception("You are trying to unload more than available");
                }
            }
            else
            {
                throw new Exception("You are trying to unload a missing cargo");
            }
        }
        protected abstract bool CheckTypes(Cargo cargos);
        
    }
}
