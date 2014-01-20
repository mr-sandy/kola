namespace Kola.Persistence.Surrogates
{
    using System.Xml.Serialization;

    using Kola.Persistence.Surrogates.ParameterValues;

    [XmlType(Namespace = "http://www.kolacms.com/2013/kola", TypeName = "parameter")]
    [XmlInclude(typeof(FixedParameterValueSurrogate))]
    [XmlInclude(typeof(InheritedParameterValueSurrogate))]
    [XmlInclude(typeof(MultilingualParameterValueSurrogate))]
    public class ParameterSurrogate
    {
        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("type")]
        public string Type { get; set; }

        [XmlElement("value")]
        public ParameterValueSurrogate Value { get; set; }
    }
}