namespace Kola.Configuration
{
    using System.Collections.Generic;

    public interface IKolaBootstrapper
    {
        void Initialise(IStartupContext startupContext);
    }

    public interface IStartupContext
    {
        IEnumerable<PluginConfiguration> FindPlugins();
    }

    public interface IKolaEngine
    {
    }
}
