
namespace Kola.Configuration.Plugins
{
    public abstract class PluginBootstrapper
    {
        private readonly PluginConfiguration pluginConfiguration = new PluginConfiguration();

        protected PluginConfigurer Configure
        {
            get { return new PluginConfigurer(this.PluginConfiguration); }
        }

        internal PluginConfiguration PluginConfiguration
        {
            get { return this.pluginConfiguration; }
        }
    }
}
