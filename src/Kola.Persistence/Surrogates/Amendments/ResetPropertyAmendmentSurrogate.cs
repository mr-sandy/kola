namespace Kola.Persistence.Surrogates.Amendments
{
    using System.Xml;
    using System.Xml.Serialization;

    [XmlType(Namespace = "http://www.kolacms.com/2013/kola", TypeName = "resetProperty")]
    public class ResetPropertyAmendmentSurrogate : AmendmentSurrogate
    {
        [XmlElement("componentPath")]
        public string ComponentPath { get; set; }

        [XmlElement("propertyName")]
        public string PropertyName { get; set; }

        public override T Accept<T>(IAmendmentSurrogateVisitor<T> visitor)
        {
            return visitor.Visit(this);
        }
    }
}