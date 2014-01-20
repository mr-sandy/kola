namespace Kola.Plugins.Core
{
    using Kola.Configuration.Plugins;
    using Kola.Plugins.Core.Handlers;

    public class Configuration : PluginConfiguration
    {
        public Configuration()
        {
            this.Configure.ViewLocation("Kola.Plugins.Core.Views");

            this.Configure.Atom("markdown")
                .WithHandler<MarkdownHandler>()
                .WithParameter("markdown", "markdown");
        }
    }
}
