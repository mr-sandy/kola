namespace Linn.Responsive.Plugin
{
    using Kola.Configuration.Plugins;

    using Linn.Responsive.Plugin.Renderers;

    public class Configuration : PluginConfiguration
    {
        public Configuration()
            : base("LinnCore")
        {
            this.Configure.ViewLocation("Kola.Plugins.Core.Views");
            this.Configure.EditorStylesheets("editor.css");

            this.Configure.Atom("markdown")
                .WithRenderer<MarkdownRenderer>()
                .WithProperty("markdown", "markdown")
                .WithProperty("lovely", "boolean");

            this.Configure.Atom("label")
                .WithView("Label")
                .WithProperty("caption", "text");

            //this.Configure.PropertyType("markdown")
            //    .WithEditor("MarkdownEditorView.js");

            //this.Configure.PropertyType("boolean")
            //    .WithEditor("BooleanEditorView.js");

            //this.Configure.PropertyType("text")
            //    .WithEditor("TextEditorView.js");
        }
    }
}
