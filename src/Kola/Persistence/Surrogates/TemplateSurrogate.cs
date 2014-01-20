namespace Kola.Persistence.Surrogates
{
    using System.Xml.Serialization;

    using Kola.Persistence.Surrogates.Amendments;

    [XmlRoot(Namespace = "http://www.kolacms.com/2013/kola", ElementName = "template")]
    public class TemplateSurrogate
    {
        [XmlArray("components")]
        [XmlArrayItem(typeof(AtomSurrogate))]
        [XmlArrayItem(typeof(ContainerSurrogate))]
        [XmlArrayItem(typeof(WidgetSurrogate))]
        public ComponentSurrogate[] Components { get; set; }

        [XmlArray("amendments")]
        [XmlArrayItem(typeof(AddComponentAmendmentSurrogate))]
        [XmlArrayItem(typeof(MoveComponentAmendmentSurrogate))]
        [XmlArrayItem(typeof(RemoveComponentAmendmentSurrogate))]
        public AmendmentSurrogate[] Amendments { get; set; }

    }
}
