namespace Kola.Persistence.Surrogates
{
    using System.Xml.Serialization;

    [XmlRoot(Namespace = "http://www.kolacms.com/2013/kola", ElementName = "widgetSpecification")]
    public class WidgetSpecificationSurrogate
    {
        [XmlArray("components")]
        [XmlArrayItem(typeof(AtomSurrogate))]
        [XmlArrayItem(typeof(ContainerSurrogate))]
        public ComponentSurrogate[] Components { get; set; }
    }
}