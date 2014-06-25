namespace Kola.Persistence.Surrogates
{
    using System.Xml.Serialization;

    [XmlType(Namespace = "http://www.kolacms.com/2013/kola", TypeName = "atom")]
    public class AtomSurrogate : ComponentSurrogate
    {
        public override T Accept<T>(IComponentSurrogateVisitor<T> visitor)
        {
            return visitor.Visit(this);
        }
    }
}