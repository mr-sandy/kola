
using Kola.Processing;

namespace Kola.Configuration.Plugins
{
    public class ContainerConfigurer
    {
        private readonly ContainerConfiguration containerConfiguration;

        internal ContainerConfigurer(ContainerConfiguration containerConfiguration)
        {
            this.containerConfiguration = containerConfiguration;
        }

        public ContainerHandlerConfigurer WithHandler<T>(string viewName = "")
        {
            this.containerConfiguration.HandlerType = typeof(T);
            this.containerConfiguration.ViewName = viewName;
            return new ContainerHandlerConfigurer(this.containerConfiguration);
        }

        public ContainerHandlerConfigurer WithView(string viewName)
        {
            return this.WithHandler<DefaultHandler>(viewName);
        }
    }
}