namespace Kola.Service.Services.Models
{
    using System.Xml.Serialization;

    [XmlRoot("urlset", Namespace = "http://www.sitemaps.org/schemas/sitemap/0.9")]
    public class SitemapModel
    {
        [XmlElement("url")]
        public SitemapItemModel[] Urls { get; set; }
    }

    public class SitemapItemModel
    {
        [XmlElement("loc")]
        public string Location { get; set; }
    }
}