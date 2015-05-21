namespace Kola.Persistence.Surrogates
{
    using System.Xml;
    using System.Xml.Serialization;

    public abstract class ComponentSurrogate
    {
        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlIgnore]
        public string Comment { get; set; }

        [XmlElement("comment")]
        public XmlNode[] CDataContent
        {
            get
            {
                return string.IsNullOrWhiteSpace(this.Comment) 
                    ? null 
                    : new XmlNode[] { new XmlDocument().CreateCDataSection(this.Comment) };
            }

            set
            {
                this.Comment = value == null
                    ? null
                    : value[0].Value;
            }
        }

        [XmlArray("properties")]
        public PropertySurrogate[] Properties { get; set; }

        public abstract T Accept<T>(IComponentSurrogateVisitor<T> visitor);
    }
}