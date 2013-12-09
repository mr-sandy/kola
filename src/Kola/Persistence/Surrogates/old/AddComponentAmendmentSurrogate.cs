namespace Kola.Persistence.Surrogates
{
    using System.Xml.Serialization;

    [XmlType(Namespace = "http://www.kolacms.com/2013/kola", TypeName = "addComponent")]
    public class AddComponentAmendmentSurrogate : AmendmentSurrogate
    {
        [XmlElement("componentType")]
        public string ComponentType { get; set; }

        [XmlElement("componentPath")]
        public string ComponentPath { get; set; }

        [XmlElement("index")]
        public int Index { get; set; }

        public override void Accept(IAmendmentSurrogateVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}