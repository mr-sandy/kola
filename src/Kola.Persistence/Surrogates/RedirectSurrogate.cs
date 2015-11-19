namespace Kola.Persistence.Surrogates
{
    using System.Xml;
    using System.Xml.Serialization;

    [XmlRoot(Namespace = "http://www.linn.co.uk/2011/cms", ElementName = "redirect")]
    public class RedirectSurrogate
    {
        [XmlIgnore]
        public string Location { get; set; }

        [XmlElement("url")]
        public XmlNode[] CDataContent
        {
            get
            {
                return string.IsNullOrWhiteSpace(this.Location)
                    ? null
                    : new XmlNode[] { new XmlDocument().CreateCDataSection(this.Location) };
            }

            set
            {
                this.Location = value?[0].Value;
            }
        }
    }
}