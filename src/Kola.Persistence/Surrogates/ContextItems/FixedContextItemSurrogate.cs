namespace Kola.Persistence.Surrogates.ContextItems
{
    using System.Xml;
    using System.Xml.Serialization;

    [XmlType(Namespace = "http://www.kolacms.com/2013/kola", TypeName = "contextItem")]
    public class FixedContextItemSurrogate : ContextItemSurrogate
    {
        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlIgnore]
        public string Value { get; set; }

        [XmlText]
        public XmlNode[] CDataContent
        {
            get
            {
                var dummy = new XmlDocument();
                return new XmlNode[] { dummy.CreateCDataSection(this.Value) };
            }

            set
            {
                this.Value = value?[0].Value;
            }
        }

        public override T Accept<T>(IContextItemSurrogateVisitor<T> visitor)
        {
            return visitor.Visit(this);
        }
    }
}