using System.Xml;

namespace Serializer
{
    public interface ISerializer
    {
        public void Serialize(XmlWriter xmlWriter);

        public object Deserialize(XmlReader xmlReader);

    }
}
