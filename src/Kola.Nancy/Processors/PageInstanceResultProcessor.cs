namespace Kola.Nancy.Processors
{
    using global::Nancy.ViewEngines;

    using Kola.Domain.Instances;

    public class PageInstanceResultProcessor : ViewResultProcessor<PageInstance>
    {
        public PageInstanceResultProcessor(IViewFactory viewFactory)
            : base(viewFactory)
        {
        }
    }
}