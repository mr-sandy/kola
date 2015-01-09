namespace Kola.Plugins.Core
{
    using Kola.Configuration.Plugins;
    using Kola.Plugins.Core.Renderers;

    public class Configuration : PluginConfiguration
    {
        public Configuration()
            : base("LinnCore")
        {
            this.Configure.ViewLocation("Kola.Plugins.Core.Views");

            this.Configure.Atom("markdown")
                .WithRenderer<MarkdownRenderer>()
                .WithProperty("markdown", "markdown")
                .WithProperty("lovely", "boolean");

            this.Configure.Atom("label")
                .WithView("Label")
                .WithProperty("caption", "text");

            this.Configure.PropertyType("markdown")
                .WithDefault("Placeholder text.")
                .WithEditor("MarkdownEditorView.js");

            this.Configure.PropertyType("boolean")
                .WithDefault("false")
                .WithEditor("BooleanEditorView.js");

            this.Configure.PropertyType("text")
                .WithEditor("TextEditorView.js");
        }
    }
}
