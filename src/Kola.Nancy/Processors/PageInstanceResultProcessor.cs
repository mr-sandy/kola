namespace Kola.Nancy.Processors
{
    using Kola.Domain.Instances;

    using global::Nancy;
    using global::Nancy.ViewEngines;

    public class PageInstanceResultProcessor : ViewResultProcessor<PageInstance>
    {
        public PageInstanceResultProcessor(IViewFactory viewFactory)
            : base(viewFactory, "Page")
        {
        }

        protected override void ResponseDecorator(Response response, PageInstance page)
        {
            if (!string.IsNullOrWhiteSpace(page.RenderingInstructions.CacheControl))
            {
                response.WithHeader("Cache-Control", page.RenderingInstructions.CacheControl);
            }
        }
    }
}