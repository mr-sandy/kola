namespace Kola.Persistence.Surrogates
{
    using System.Xml.Serialization;

    public abstract class ComponentSurrogate
    {
        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlArray("properties")]
        public PropertySurrogate[] Properties { get; set; }

        public abstract T Accept<T>(IComponentSurrogateVisitor<T> visitor);
    }
}