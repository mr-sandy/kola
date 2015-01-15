namespace Kola.Persistence.Surrogates
{
    using System.Xml.Serialization;

    [XmlType(Namespace = "http://www.kolacms.com/2013/kola", TypeName = "propertySpecification")]
    public class PropertySpecificationSurrogate
    {
        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("type")]
        public string Type { get; set; }
    }
}