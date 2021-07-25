using System.Xml;

namespace Serializer
{
    /// <summary>
    /// Contains methods who allow read and write to xml
    /// </summary>
    public interface ISerializer
    {
        /// <summary>
        /// Serialise object
        /// </summary>
        /// <param name="xmlWriter">XML Writer</param>
        public void Serialize(XmlWriter xmlWriter);

        /// <summary>
        /// Deserialise object
        /// </summary>
        /// <param name="xmlReader">XML Reader</param>
        public void Deserialize(XmlReader xmlReader);

    }
}
