namespace Kola.Configuration
{
    using System.Collections.Generic;

    using Kola.Configuration.Plugins;

    public interface IPluginFinder
    {
        IEnumerable<PluginConfiguration> FindPlugins();
    }
}