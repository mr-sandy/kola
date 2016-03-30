namespace Kola.Persistence.Surrogates.PropertyValues
{
    using System.Xml.Serialization;

    [XmlType(Namespace = "http://www.kolacms.com/2013/kola", TypeName = "variable")]
    public class VariablePropertyValueSurrogate : PropertyValueSurrogate
    {
        [XmlArray("variants")]
        public PropertyVariantSurrogate[] Variants { get; set; }

        [XmlAttribute("contextName")]
        public string ContextName { get; set; }

        public override T Accept<T>(IPropertyValueSurrogateVisitor<T> visitor)
        {
            return visitor.Visit(this);
        }
    }
}