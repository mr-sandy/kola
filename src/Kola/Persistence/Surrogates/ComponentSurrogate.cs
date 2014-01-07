namespace Kola.Persistence.Surrogates
{
    using System.Xml.Serialization;

    public abstract class ComponentSurrogate
    {
        [XmlAttribute("name")]
        public string Name { get; set; }

        public abstract void Accept(IComponentSurrogateVisitor visitor);
    }
}