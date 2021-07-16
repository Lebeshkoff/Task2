using System.Xml;

namespace Serializer
{
    public interface ISerializer
    {
        public void Serialize(XmlWriter xmlWriter);

        public void Deserialize(XmlReader xmlReader);

    }
}
