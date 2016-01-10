namespace Kola.Persistence.Surrogates
{
    using System.Xml.Serialization;

    using Kola.Persistence.Surrogates.Amendments;

    [XmlRoot(Namespace = "http://www.kolacms.com/2013/kola", ElementName = "widgetSpecification")]
    public class WidgetSpecificationSurrogate
    {
        [XmlAttribute("category")]
        public string Category { get; set; }

        [XmlArray("components")]
        [XmlArrayItem(typeof(AtomSurrogate))]
        [XmlArrayItem(typeof(ContainerSurrogate))]
        [XmlArrayItem(typeof(WidgetSurrogate))]
        [XmlArrayItem(typeof(PlaceholderSurrogate))]
        public ComponentSurrogate[] Components { get; set; }

        [XmlArray("propertySpecifications")]
        public PropertySpecificationSurrogate[] PropertySpecifications { get; set; }

        [XmlArray("amendments")]
        [XmlArrayItem(typeof(AddComponentAmendmentSurrogate))]
        [XmlArrayItem(typeof(MoveComponentAmendmentSurrogate))]
        [XmlArrayItem(typeof(RemoveComponentAmendmentSurrogate))]
        [XmlArrayItem(typeof(DuplicateComponentAmendmentSurrogate))]
        [XmlArrayItem(typeof(SetPropertyFixedAmendmentSurrogate))]
        [XmlArrayItem(typeof(SetPropertyInheritedAmendmentSurrogate))]
        [XmlArrayItem(typeof(ResetPropertyAmendmentSurrogate))]
        [XmlArrayItem(typeof(SetCommentAmendmentSurrogate))]
        public AmendmentSurrogate[] Amendments { get; set; }

    }
}