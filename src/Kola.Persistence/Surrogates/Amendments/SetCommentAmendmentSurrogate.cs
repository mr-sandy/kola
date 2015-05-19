namespace Kola.Persistence.Surrogates.Amendments
{
    using System.Xml;
    using System.Xml.Serialization;

    [XmlType(Namespace = "http://www.kolacms.com/2013/kola", TypeName = "setComment")]
    public class SetCommentAmendmentSurrogate : AmendmentSurrogate
    {
        [XmlElement("componentPath")]
        public string ComponentPath { get; set; }

        [XmlIgnore]
        public string Comment { get; set; }

        [XmlElement("comment")]
        public XmlNode[] CDataContent
        {
            get
            {
                var dummy = new XmlDocument();
                return new XmlNode[] { dummy.CreateCDataSection(this.Comment) };
            }

            set
            {
                this.Comment = value == null
                                      ? null
                                      : value[0].Value;
            }
        }

        public override T Accept<T>(IAmendmentSurrogateVisitor<T> visitor)
        {
            return visitor.Visit(this);
        }
    }
}