namespace Kola.Configuration.Fluent
{
    using Kola.Rendering;

    public class ComponentConfigurer
    {
        private readonly ComponentSpecification specification;

        internal ComponentConfigurer(ComponentSpecification specification)
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