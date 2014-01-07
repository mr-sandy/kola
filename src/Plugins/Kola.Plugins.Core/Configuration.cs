using Kola.Configuration;
using Kola.Plugins.Core.Handlers;

namespace Kola.Plugins.Core
{
    using Kola.Configuration.Plugins;

    public class Configuration : PluginConfiguration
    {
        public Configuration()
        {
            this.Configure.ViewLocation("Kola.Plugins.Core.Views");

            this.Configure.Component("markdown")
                .WithHandler<MarkdownHandler>();
        }
    }
}
