namespace Kola.Nancy.Processors
{
    using global::Nancy;
    using global::Nancy.ViewEngines;

    using Kola.Domain.Instances;

    public class PageInstanceResultProcessor : ViewResultProcessor<PageInstance>
    {
        public PageInstanceResultProcessor(IViewFactory viewFactory)
            : base(viewFactory, "Page")
        {
        }

        protected override void ResponseDecorator(Response response, PageInstance page)
        {
            response.WithHeader(
                "Cache-Control",
                page.RenderingInstructions.UseCache ? "public, max-age=600" : "no-cache");
        }
    }
}