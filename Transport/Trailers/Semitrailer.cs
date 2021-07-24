using System;
using CargoTransportLib.Trucks;
using CargoTransportLib.Cargos;
using System.Collections.Generic;
using System.ComponentModel;
using Serializer;
using System.Xml;

namespace CargoTransportLib.Trailers
{
    public abstract class Semitrailer : ISerializer
    {
        public int carrying;
        public int Weight { get; protected set; }
        public List<Cargo> cargos = new List<Cargo>();

        public virtual void LoadCargo(Cargo cargo)
        {
            if (cargos.Count == 0)
            {
                cargos.Add(cargo);
                Weight += cargo.Weight;
                return;
            }
            else
            {
                if (cargo is Goods goods)
                {
                    var currentCargo = cargos.Find(x => x is Goods
                    && ((Goods)x).name == goods.name
                    && ((Goods)x).type == goods.type
                    && ((Goods)x).StorageTemperature == goods.StorageTemperature);

                    if (currentCargo != null)
                    {
                        cargos.Remove(currentCargo);
                        cargos.Add(new Goods(goods.type, goods.StorageTemperature, goods.Weight + currentCargo.Weight, goods.name));
                    }
                    else
                    {
                        if (goods.type == ((Goods)cargos[0]).type && cargos[0].StorageTemperature == goods.StorageTemperature)
                        {
                            cargos.Add(goods);
                        }
                        else
                        {
                            throw new Exception("Invalid types or different storage temperature");
                        }
                    }
                }
                if (cargo is Liquid liquid)
                {
                    var currentCargo = cargos.Find(x => x is Liquid
                    && ((Liquid)x).type == liquid.type);
                    if (((Liquid)currentCargo).type != liquid.type || currentCargo == null)
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
        public abstract void Serialize(XmlWriter xmlWriter);
        public abstract void Deserialize(XmlReader xmlReader);
    }
}
