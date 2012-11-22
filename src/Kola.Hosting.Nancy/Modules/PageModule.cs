using Nancy;
using Nancy.Responses.Negotiation;

namespace Kola.Hosting.Nancy.Modules
{
    public class PageModule : NancyModule
    {
        private readonly IPageHandler pageHandler;

        public PageModule(IPageHandler pageHandler)
        {
            this.pageHandler = pageHandler;
            this.Get["(?<templatePath>.*)"] = this.GetPage;
        }

        private Negotiator GetPage(dynamic parameters)
        {
            var page = this.pageHandler.GetPage((string)parameters.templatePath);
            
            return this.Negotiate
                .WithAllowedMediaRange("application/xml")
                .WithModel(page);
        }
    }
}