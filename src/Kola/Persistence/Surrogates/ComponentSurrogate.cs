namespace Kola.Persistence.Surrogates
{
    using System.Xml.Serialization;

    public abstract class ComponentSurrogate
    {
        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlArray("parameters")]
        public ParameterSurrogate[] Parameters { get; set; }

        public abstract T Accept<T>(IComponentSurrogateVisitor<T> visitor);
    }
}