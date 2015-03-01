namespace Kola.Persistence.Surrogates.Amendments
{
    using System.Xml.Serialization;

    [XmlType(Namespace = "http://www.kolacms.com/2013/kola", TypeName = "addComponent")]
    public class AddComponentAmendmentSurrogate : AmendmentSurrogate
    {
        [XmlElement("componentType")]
        public string ComponentType { get; set; }

        [XmlElement("targetPath")]
        public string TargetPath { get; set; }

        public override T Accept<T>(IAmendmentSurrogateVisitor<T> visitor)
        {
            return visitor.Visit(this);
        }
    }
}