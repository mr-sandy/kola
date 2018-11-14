namespace Kola.Nancy.Modules
{
    using global::Nancy;
    using Kola.Service.Services;

    public class SitemapModule : NancyModule
    {
        private readonly ISitemapService sitemapService;

        public SitemapModule(ISitemapService sitemapService)
        {
            this.sitemapService = sitemapService;
            this.Get["/sitemap"] = this.GetSitemap;

        }

        private object GetSitemap(dynamic _)
        {
            var sitemap = this.sitemapService.GetSitemap();

            return this.Negotiate.WithModel(sitemap);
        }
    }
}