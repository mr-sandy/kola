namespace Kola.Configuration.Fluent
{
    using Kola.Domain.Composition;
    using Kola.Domain.Rendering;
    using Kola.Domain.Specifications;

    public class ComponentConfigurer
    {
        private readonly IPluginComponentSpecification<IComponentWithProperties> specification;

        internal ComponentConfigurer(IPluginComponentSpecification<IComponentWithProperties> specification)
        {
            this.specification = specification;
        }

        public ComponentRendererConfigurer WithRenderer<T>(string viewName = "")
        {
            this.specification.RendererType = typeof(T);
            this.specification.ViewName = viewName;
            return new ComponentRendererConfigurer(this.specification);
        }

        public ComponentRendererConfigurer WithView(string viewName)
        {
            return this.WithRenderer<DefaultRenderer>(viewName);
        }
    }
}