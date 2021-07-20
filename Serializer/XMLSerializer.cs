using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Serializer
{
    public class XMLSerializer
    {
        private XmlWriter writer;

        public XMLSerializer(string path)
        {
            writer = XmlWriter.Create(path);
            writer.WriteStartDocument();
        }

        public void Serialize(object obj)
        {
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
    }
}
