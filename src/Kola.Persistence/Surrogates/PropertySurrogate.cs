namespace Kola.Persistence.Surrogates
{
    using System.Xml.Serialization;

    using Kola.Persistence.Surrogates.PropertyValues;

    [XmlType(Namespace = "http://www.kolacms.com/2013/kola", TypeName = "property")]
    [XmlInclude(typeof(FixedPropertyValueSurrogate))]
    [XmlInclude(typeof(InheritedPropertyValueSurrogate))]
    [XmlInclude(typeof(VariablePropertyValueSurrogate))]
    public class PropertySurrogate
    {
        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("type")]
        public string Type { get; set; }

        [XmlElement("value")]
        public PropertyValueSurrogate Value { get; set; }
    }
}