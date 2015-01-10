namespace Kola.Persistence.Surrogates.PropertyValues
{
    using System.Xml;
    using System.Xml.Serialization;

    [XmlType(Namespace = "http://www.kolacms.com/2013/kola", TypeName = "fixed")]
    public class FixedPropertyValueSurrogate : PropertyValueSurrogate
    {
        [XmlIgnore]
        public string Value { get; set; }
        
        [XmlText]
        public XmlNode[] CDataContent
        {
            get
            {
                var dummy = new XmlDocument();
                return new XmlNode[] { dummy.CreateCDataSection(this.Value) };
            }

            set
            {
                this.Value = value == null 
                    ? null 
                    : value[0].Value;
            }
        }

        public override T Accept<T>(IPropertyValueSurrogateVisitor<T> visitor)
        {
            return visitor.Visit(this);
        }
    }
}