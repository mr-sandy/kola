namespace Kola.Persistence.Surrogates.ContextItems
{
    using System.Xml.Serialization;

    [XmlType(Namespace = "http://www.kolacms.com/2013/kola", TypeName = "randomContext")]
    public class RandomContextItemSurrogate : ContextItemSurrogate
    {
        [XmlElement("contextItems")]
        public ContextItemGroup[] ContextItemGroups { get; set; }

        public override T Accept<T>(IContextItemSurrogateVisitor<T> visitor)
        {
            return visitor.Visit(this);
        }
    }
}