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
            if(typeof(ISerializer).IsAssignableTo(obj.GetType()))
            {
                ((ISerializer)obj).Serialize(writer);
                writer.WriteEndDocument();
                writer.Close();
            }
            else
            {
                throw new Exception("Class" + obj.GetType().Name + " non serializable.");
            }
        }
    }
}
