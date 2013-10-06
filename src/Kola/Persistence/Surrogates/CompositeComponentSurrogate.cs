namespace Kola.Persistence.Surrogates
{
    using System.Xml.Serialization;

    [XmlType(Namespace = "http://www.kolacms.com/2013/kola", TypeName = "compositeComponent")]
    public class CompositeComponentSurrogate : ComponentSurrogate
    {
        [XmlArray("components")]
        [XmlArrayItem(typeof(SimpleComponentSurrogate))]
        [XmlArrayItem(typeof(CompositeComponentSurrogate))]
        public ComponentSurrogate[] Components { get; set; }

        public override void Accept(IComponentSurrogateVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}