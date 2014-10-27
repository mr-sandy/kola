namespace Kola.Plugins.Core
{
    using Kola.Configuration.Plugins;
    using Kola.Plugins.Core.Renderers;

    public class Configuration : PluginConfiguration
    {
        public Configuration()
        {
            this.Configure.ViewLocation("Kola.Plugins.Core.Views");

            this.Configure.Atom("markdown")
                .WithRenderer<MarkdownRenderer>()
                .WithParameter("markdown", "markdown");

            this.Configure.ParameterType("markdown")
                .WithDefault("Placeholder text.")
                .WithEditor("MarkdownEditorView.js");
        }
    }
}
