using Kola.Configuration;
using Kola.Nancy.Razor.Plugins.Core.Handlers;

namespace Kola.Nancy.Razor.Plugins.Core
{
    public class Configuration : PluginConfiguration
    {
        public Configuration()
        {
            this.Configure.ViewLocation("Kola.Nancy.Razor.Plugins.Core.Views");

            this.Configure.Component("markdown")
                .WithHandler<MarkdownHandler>();
        }
    }
}
