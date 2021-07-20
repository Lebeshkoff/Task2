﻿using CargoTransportLib.Cargos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace CargoTransportLib.Trailers
{
    public class Titl : Semitrailer
    {
        public Titl(int carrying = 0)
        {
            this.carrying = carrying;
        }

        public override void Deserialize(XmlReader xmlReader)
        {
            while (xmlReader.Read())
            {
                if (xmlReader.Name == "Goods")
                {
                    var goods = new Goods();
                    goods.Deserialize(xmlReader);
                    cargos.Add(goods);
                }
                if (xmlReader.Name == "Weight")
                {
                    Weight = int.Parse(xmlReader.Value);
                }
                if (xmlReader.Name == "Carrying")
                {
                    carrying = int.Parse(xmlReader.Value);
                }
            }
        }

        public override void LoadCargo(Cargo cargo)
        {
            if(cargo.StorageTemperature < 30)
            {
                throw new Exception("Use refrigerator for this type of goods");
            }
            base.LoadCargo(cargo);
        }

        public override void Serialize(XmlWriter xmlWriter)
        {
            xmlWriter.WriteStartElement("Semitrailer");
            xmlWriter.WriteAttributeString("Type", GetType().Name);
            xmlWriter.WriteStartElement("Weight");
            xmlWriter.WriteValue(Weight);
            xmlWriter.WriteEndElement();
            xmlWriter.WriteStartElement("Carrying");
            xmlWriter.WriteValue(carrying);
            xmlWriter.WriteEndElement();
            xmlWriter.WriteStartElement("Cargos");
            foreach (var cargo in cargos)
            {
                cargo.Serialize(xmlWriter);
            }
            xmlWriter.WriteEndElement();
            xmlWriter.WriteEndElement();
        }

        protected override bool CheckTypes(Cargo cargos)
        {
            throw new NotImplementedException(); //TODO
        }
    }
}
