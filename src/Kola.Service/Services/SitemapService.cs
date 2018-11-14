namespace Kola.Service.Services
{
    using System.Linq;
    using Kola.Persistence;
    using Kola.Service.Services.Models;

    public class SitemapService : ISitemapService
    {
        private readonly IContentLister contentLister;

        public SitemapService(IContentLister contentLister)
        {
            this.contentLister = contentLister;
        }


        public SitemapModel GetSitemap()
        {
            var paths = this.contentLister.FindAllPaths();

            return new SitemapModel
            {
                Urls = paths.Select(path => new SitemapItemModel { Location = $"https://www.linn.co.uk{path}"  }).ToArray()
            };
        }
    }
}