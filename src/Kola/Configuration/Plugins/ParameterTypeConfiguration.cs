using System;

namespace Kola.Configuration.Plugins
{
    public class ParameterTypeConfiguration : Exception
    {
        private readonly PluginConfiguration pluginConfiguration;

        internal ParameterTypeConfiguration(PluginConfiguration pluginConfiguration)
        {
            this.pluginConfiguration = pluginConfiguration;
        }

        public ParameterTypeConfiguration DefaultTo(string value)
        {
            return this;
        }

        public ParameterTypeConfiguration WithEditor(string editor)
        {
            return this;
        }
    }
}