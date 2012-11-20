
namespace Kola.Configuration.Plugins
{
    public class ContainerConfigurer
    {
        private readonly PluginConfiguration pluginConfiguration;

        internal ContainerConfigurer(PluginConfiguration pluginConfiguration)
        {
            this.pluginConfiguration = pluginConfiguration;
        }

        public ContainerHandlerConfigurer WithHandler<T>(string view = "")
        {
            return null;
        }

        public ContainerHandlerConfigurer WithView(string view)
        {
            //return this.WithHandler<DefaultHandler>(view);
            return null;
        }

    }
}