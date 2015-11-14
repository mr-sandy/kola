namespace Kola.Nancy.Modules
{
    using global::Nancy;
    using global::Nancy.ModelBinding;
    using global::Nancy.Responses;
    using global::Nancy.Responses.Negotiation;

    using Kola.Nancy.Extensions;
    using Kola.Service.Services;

    public class RenderingModule : NancyModule
    {
        private readonly IRenderingService renderingService;

        public RenderingModule(IRenderingService renderingService)
        {
            this.renderingService = renderingService;
            this.Get["/"] = p => this.GetPage();
            this.Get["/(.*)"] = p => this.GetPage();
            this.Get["/{path*}"] = p => this.GetPage();
        }


        private dynamic GetPage()
        {
            var path = this.Request.Path.ParsePath();
            var query = this.Bind<RenderQuery>();

            var model = this.renderingService.GetPage(path, query.IsPreview);

            return this.Negotiate.WithModel(model);
        }
    }
}