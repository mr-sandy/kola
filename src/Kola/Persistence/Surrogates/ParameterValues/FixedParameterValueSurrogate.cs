namespace Kola.Persistence.Surrogates.ParameterValues
{
    using System.Xml;
    using System.Xml.Serialization;

    [XmlType(Namespace = "http://www.kolacms.com/2013/kola", TypeName = "fixed")]
    public class FixedParameterValueSurrogate : ParameterValueSurrogate
    {
        [XmlText]
        public string Value { get; set; }

        //TODO {SC} Put my own CDATA wrappers here?
        [XmlIgnore]
        public XmlCDataSection ValueAsCData
        {
            get
            {
                var doc = new XmlDocument();
                return doc.CreateCDataSection(this.Value);
            }

            set
            {
                this.Value = value.Value;
            }
        }

        public override T Accept<T>(IParameterValueSurrogateVisitor<T> visitor)
        {
            return visitor.Visit(this);
        }
    }
}