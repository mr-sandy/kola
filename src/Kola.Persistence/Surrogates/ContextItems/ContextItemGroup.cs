namespace Kola.Persistence.Surrogates.ContextItems
{
    using System.Xml.Serialization;

    public class ContextItemGroup
    {
        [XmlElement("contextItem")]
        public FixedContextItemSurrogate[] ContextItems { get; set; }
    }
}