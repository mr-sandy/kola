namespace Kola.Persistence.Surrogates.PropertyValues
{
    using System.Xml;
    using System.Xml.Serialization;

    [XmlType(Namespace = "http://www.kolacms.com/2013/kola", TypeName = "variant")]
    [XmlInclude(typeof(FixedPropertyValueSurrogate))]
    [XmlInclude(typeof(InheritedPropertyValueSurrogate))]
    [XmlInclude(typeof(VariablePropertyValueSurrogate))]
    public class PropertyVariantSurrogate
    {
        [XmlAttribute("contextValue")]
        public string ContextValue { get; set; }

        [XmlElement("value")]
        public PropertyValueSurrogate Value { get; set; }

        [XmlAttribute("default")]
        public bool IsDefault { get; set; }
    }
}