using Kola.Rendering;

namespace Kola.Configuration.Fluent
{
    public class ComponentConfigurer
    {
        private readonly ComponentConfiguration configuration;

        internal ComponentConfigurer(ComponentConfiguration componentConfiguration)
        {
            this.configuration = componentConfiguration;
        }

        public ComponentHandlerConfigurer WithHandler<T>(string viewName = "")
        {
            this.configuration.HandlerType = typeof(T);
            this.configuration.ViewName = viewName;
            return new ComponentHandlerConfigurer(this.configuration);
        }

        public ComponentHandlerConfigurer WithView(string viewName)
        {
            return this.WithHandler<DefaultHandler>(viewName);
        }
    }
}