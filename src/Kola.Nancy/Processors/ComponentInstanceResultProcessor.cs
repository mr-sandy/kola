namespace Kola.Nancy.Processors
{
    using global::Nancy.ViewEngines;

    using Kola.Domain.Instances;

    public class ComponentInstanceResultProcessor : ViewResultProcessor<ComponentInstance>
    {
        public ComponentInstanceResultProcessor(IViewFactory viewFactory)
            : base(viewFactory, "Fragment")
        {
        }
    }
}