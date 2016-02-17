namespace Kola.Persistence.Surrogates
{
    using System.Xml;
    using System.Xml.Serialization;

    using Kola.Persistence.Surrogates.Conditions;

    [XmlRoot(Namespace = "http://www.kolacms.com/2013/kola", ElementName = "configuration")]
    public class ConfigurationSurrogate
    {
        [XmlArray("contextItems")]
        public ContextItemSurrogate[] ContextItems { get; set; }

        [XmlArray("conditions")]
        [XmlArrayItem(typeof(IsAuthenticatedConditionSurrogate))]
        [XmlArrayItem(typeof(HasAllClaimsConditionSurrogate))]
        [XmlArrayItem(typeof(HasAnyClaimsConditionSurrogate))]
        public ConditionSurrogate[] Conditions { get; set; }
        
        [XmlIgnore]
        public string CacheControl { get; set; }

        [XmlElement("cacheControl")]
        public XmlNode[] CDataContent
        {
            get
            {
                return new XmlNode[] { new XmlDocument().CreateCDataSection(this.CacheControl) };
            }
            set
            {
                this.CacheControl = value?[0].Value;
            }
        }
    }
}