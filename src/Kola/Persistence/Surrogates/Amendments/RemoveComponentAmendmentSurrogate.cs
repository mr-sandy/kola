namespace Kola.Persistence.Surrogates.Amendments
{
    using System.Xml.Serialization;

    [XmlType(Namespace = "http://www.kolacms.com/2013/kola", TypeName = "removeComponent")]
    public class RemoveComponentAmendmentSurrogate : AmendmentSurrogate
    {
        [XmlElement("componentPath")]
        public string ComponentPath { get; set; }

        public override void Accept(IAmendmentSurrogateVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}