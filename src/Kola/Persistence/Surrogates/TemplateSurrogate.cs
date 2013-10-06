namespace Kola.Persistence.Surrogates
{
    using System.Xml.Serialization;

    [XmlRoot(Namespace = "http://www.kolacms.com/2013/kola", ElementName = "template")]
    public class TemplateSurrogate
    {
        [XmlArray("components")]
        [XmlArrayItem(typeof(SimpleComponentSurrogate))]
        [XmlArrayItem(typeof(CompositeComponentSurrogate))]
        public ComponentSurrogate[] Components { get; set; }

        [XmlArray("amendments")]
        [XmlArrayItem(typeof(AddComponentAmendmentSurrogate))]
        [XmlArrayItem(typeof(MoveComponentAmendmentSurrogate))]
        public AmendmentSurrogate[] Amendments { get; set; }

    }
}
