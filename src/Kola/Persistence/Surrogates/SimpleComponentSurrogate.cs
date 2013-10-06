namespace Kola.Persistence.Surrogates
{
    using System.Xml.Serialization;

    [XmlType(Namespace = "http://www.kolacms.com/2013/kola", TypeName = "simpleComponent")]
    public class SimpleComponentSurrogate : ComponentSurrogate
    {
        public override void Accept(IComponentSurrogateVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}