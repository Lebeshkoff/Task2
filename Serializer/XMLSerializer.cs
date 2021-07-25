using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Serializer
{
    /// <summary>
    /// Serialization handler 
    /// </summary>
    public class XMLSerializer
    {
        /// <summary>
        /// Class who write to xml file
        /// </summary>
        private XmlWriter writer;

        /// <param name="path">File save path</param>
        public XMLSerializer(string path)
        {
            writer = XmlWriter.Create(path);
            writer.WriteStartDocument();
        }

        /// <summary>
        /// Serialize object
        /// </summary>
        /// <param name="obj">object</param>
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
