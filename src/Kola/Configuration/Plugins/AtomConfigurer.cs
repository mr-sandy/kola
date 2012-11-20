
namespace Kola.Configuration.Plugins
{
    public class AtomConfigurer
    {
        internal AtomConfigurer(PluginConfiguration pluginConfiguration, string atomName)
        {
        }

        public AtomHandlerConfigurer WithHandler<T>(string view = "")
        {
            return null;
        }

        public AtomHandlerConfigurer WithView(string view)
        {
            //return this.WithHandler<DefaultHandler>(view);
            return null;
        }
    }
}