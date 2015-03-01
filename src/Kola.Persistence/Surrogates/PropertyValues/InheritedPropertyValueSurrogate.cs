namespace Kola.Persistence.Surrogates.PropertyValues
{
    using System.Xml.Serialization;

    [XmlType(Namespace = "http://www.kolacms.com/2013/kola", TypeName = "inherited")]
    public class InheritedPropertyValueSurrogate : PropertyValueSurrogate
    {
        [XmlAttribute("key")]
        public string Key { get; set; }

        public override T Accept<T>(IPropertyValueSurrogateVisitor<T> visitor)
        {
            return visitor.Visit(this);
        }
    }
}
