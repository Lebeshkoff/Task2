﻿using CargoTransportLib.Cargos;
using System;
using Serializer;
using System.Xml;

namespace CargoTransportLib.Trailers
{
    public class Refrigerator : Semitrailer , IChilled
    {
        public int Temperature { get; set; }
        public GoodsType Type { get; set; }

        public Refrigerator(int carrying = 0)
        {
            this.carrying = carrying;
        }


        public override void LoadCargo(Cargo cargo)
        {
            if(cargos.Count == 0 && cargo is Goods)
            {
                Temperature = cargo.StorageTemperature;
                Type = ((Goods)cargo).type;
            }
            base.LoadCargo(cargo);
        }

        public override void Serialize(XmlWriter xmlWriter)
        {
            xmlWriter.WriteStartElement("Semitrailer");
            xmlWriter.WriteAttributeString("Type", GetType().Name);
            xmlWriter.WriteStartElement("Temperature");
            xmlWriter.WriteValue(Temperature);
            xmlWriter.WriteEndElement();
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

        public override void Deserialize(XmlReader xmlReader)
        {
            while (xmlReader.Read())
            {
                if (xmlReader.NodeType != XmlNodeType.EndElement)
                {
                    if (xmlReader.Name == "Goods")
                    {
                        var goods = new Goods();
                        goods.Deserialize(xmlReader);
                        cargos.Add(goods);
                    }
                    if (xmlReader.Name == "Weight")
                    {
                        xmlReader.Read();
                        Weight = int.Parse(xmlReader.Value);
                    }
                    if (xmlReader.Name == "Carrying")
                    {
                        xmlReader.Read();
                        carrying = int.Parse(xmlReader.Value);
                    }
                    if (xmlReader.Name == "Temperature")
                    {
                        xmlReader.Read();
                        Temperature = int.Parse(xmlReader.Value);
                    }
                }
                if (xmlReader.NodeType == XmlNodeType.EndElement && xmlReader.Name == "Semitrailer")
                {
                    break;
                }
            }
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (obj as Refrigerator == null) return false;
            return Type == ((Refrigerator)obj).Type &&
                Temperature == ((Refrigerator)obj).Temperature &&
                Weight == ((Refrigerator)obj).Weight &&
                cargos.Equals(((Refrigerator)obj).cargos) &&
                carrying == ((Refrigerator)obj).carrying;
        }

        public override int GetHashCode()
        {
            return Type.GetHashCode() ^ Temperature.GetHashCode() ^
                Weight.GetHashCode() ^ carrying.GetHashCode() ^ cargos.GetHashCode();
        }

        public override string ToString()
        {
            return "Refrigerator {Type: " + Type + " Temperature: " + Temperature + "Carrying: " + carrying + " Weight: " + Weight + " }";
        }
    }
}
