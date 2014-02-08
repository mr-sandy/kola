namespace Kola.Configuration.Fluent
{
    using Kola.Domain.Rendering;
    using Kola.Domain.Specifications;
    using Kola.Domain.Templates;

    public class ComponentConfigurer
    {
        private readonly IPluginComponentSpecification<IComponentTemplate> specification;

        internal ComponentConfigurer(IPluginComponentSpecification<IComponentTemplate> specification)
        {
            this.specification = specification;
        }

        public ComponentHandlerConfigurer WithHandler<T>(string viewName = "")
        {
            this.specification.HandlerType = typeof(T);
            this.specification.ViewName = viewName;
            return new ComponentHandlerConfigurer(this.specification);
        }

        public ComponentHandlerConfigurer WithView(string viewName)
        {
            return this.WithHandler<DefaultHandler>(viewName);
        }
    }
}