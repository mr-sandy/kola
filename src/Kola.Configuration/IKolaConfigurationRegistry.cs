namespace Kola.Configuration
{
    using System.Collections.Generic;

    using Kola.Configuration.Plugins;
    using Kola.Domain.Rendering;

    public interface IKolaConfigurationRegistry
    {
        IEnumerable<PluginConfiguration> Plugins { get; }

        MultiRenderer Renderer { get; }
    }
}