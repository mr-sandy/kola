namespace Kola.Persistence.Surrogates
{
    using System;
    using System.Xml.Serialization;

    [XmlType(Namespace = "http://www.kolacms.com/2013/kola", TypeName = "atom")]
    public class AtomSurrogate : ComponentSurrogate
    {
        public override void Accept(IComponentSurrogateVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}