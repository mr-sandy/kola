namespace Kola.Persistence.Surrogates.Amendments
{
    using System.Xml;
    using System.Xml.Serialization;

    [XmlType(Namespace = "http://www.kolacms.com/2013/kola", TypeName = "setProperty")]
    public class SetPropertyFixedAmendmentSurrogate : AmendmentSurrogate
    {
        [XmlElement("componentPath")]
        public string ComponentPath { get; set; }

        [XmlElement("propertyName")]
        public string PropertyName { get; set; }

        [XmlIgnore]
        public string FixedValue { get; set; }

        [XmlElement("fixedValue")]
        public XmlNode[] CDataContent
        {
            get
            {
                var dummy = new XmlDocument();
                return new XmlNode[] { dummy.CreateCDataSection(this.FixedValue) };
            }

            set
            {
                this.FixedValue = value == null
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

