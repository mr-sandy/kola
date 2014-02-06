namespace Kola.Persistence.Surrogates
{
    using System.Xml.Serialization;

    [XmlType(Namespace = "http://www.kolacms.com/2013/kola", TypeName = "area")]
    public class AreaSurrogate
    {
        [XmlArray("components")]
        [XmlArrayItem(typeof(AtomSurrogate))]
        [XmlArrayItem(typeof(ContainerSurrogate))]
        [XmlArrayItem(typeof(WidgetSurrogate))]
        [XmlArrayItem(typeof(PlaceholderSurrogate))]
        public ComponentSurrogate[] Components { get; set; }
    }
}