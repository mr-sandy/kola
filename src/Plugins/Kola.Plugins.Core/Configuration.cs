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
                .WithParameter("markdown", "markdown")
                .WithParameter("lovely", "boolean");

            this.Configure.Atom("label")
                .WithRenderer<LabelRenderer>()
                .WithParameter("caption", "text");

            this.Configure.ParameterType("markdown")
                .WithDefault("Placeholder text.")
                .WithEditor("MarkdownEditorView.js");

            this.Configure.ParameterType("boolean")
                .WithDefault("false")
                .WithEditor("BooleanEditorView.js");

            this.Configure.ParameterType("text")
                .WithEditor("TextEditorView.js");
        }
    }
}
