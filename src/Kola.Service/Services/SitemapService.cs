namespace Kola.Service.Services
{
    using System.Linq;
    using Kola.Domain.Composition;
    using Kola.Persistence;
    using Kola.Service.Services.Models;

    public class SitemapService : ISitemapService
    {
        private readonly IContentRepository contentRepository;
        private readonly IPathInstanceBuilder pathInstanceBuilder;
        private readonly string sitemapDomainName;

        public SitemapService(IContentRepository contentRepository, IPathInstanceBuilder pathInstanceBuilder, string sitemapDomainName)
        {
            this.contentRepository = contentRepository;
            this.pathInstanceBuilder = pathInstanceBuilder;
            this.sitemapDomainName = sitemapDomainName;
        }


        public SitemapModel GetSitemap()
        {
            var templatePaths = this.contentRepository.GetAllTemplatePaths();

            var paths  = templatePaths.SelectMany(path => this.pathInstanceBuilder.Build(path, false));

            return new SitemapModel
            {
                Urls = paths.Select(path => new SitemapItemModel { Location = $"{this.sitemapDomainName}{path}"  }).ToArray()
            };
        }
    }
}