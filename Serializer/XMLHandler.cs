using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Serializer
{
    public class XMLHandler
    {
        private XmlWriter writer;

        public XMLHandler(string path)
        {
            writer = XmlWriter.Create(path);
            writer.WriteStartDocument();
        }

        public void Serialize(object obj)
        {
            //var g = obj.GetType().GetInterfaces().ToList();
            if (typeof(ISerializer) == obj.GetType().GetInterfaces().ToList().Find(x => x == typeof(ISerializer)))
            {
                ((ISerializer)obj).Serialize(writer);
                writer.WriteEndDocument();
                writer.Close();
            }
            else
            {
                throw new Exception("Class " + obj.GetType().Name + " non serializable.");
            }
        }
        public object Deserialize(string path)
        {
            var a = XmlReader.Create(path);
            while (a.Read())
            {
                var s = a.NodeType;
                var n = a.Name;
                var g = a.ReadAttributeValue();
                if(a.AttributeCount != 0)
                {
                    var v = a.GetAttribute(0);
                }
            }
            var f = 1;
            throw new NotSupportedException();
        }
    }
}
