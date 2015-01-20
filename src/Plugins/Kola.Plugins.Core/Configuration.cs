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
            this.Configure.EditorStylesheets("editor.css");

            this.ConfigureAtoms();

            this.ConfigureContainers();

            this.ConfigurePropertyTypes();
        }

        private void ConfigureAtoms()
        {
            this.Configure.Atom("markdown")
                .WithRenderer<MarkdownRenderer>()
                .WithProperty("markdown", "markdown", "*add content here*");

            this.Configure.Atom("label")
                .WithView("Label")
                .WithProperty("caption", "text");

            this.Configure.Atom("html-title")
                .WithView("HtmlTitle")
                .WithProperty("title", "text");

            this.Configure.Atom("image")
                .WithView("Image")
                .WithProperty("src", "text")
                .WithProperty("alt", "text");

            this.Configure.Atom("html-metadata")
                .WithView("HtmlMetadata")
                .WithProperty("name", "text")
                .WithProperty("content", "text")
                .WithProperty("charset", "text")
                .WithProperty("httpEquiv", "text");

            this.Configure.Atom("html-style")
                .WithView("HtmlStyle")
                .WithProperty("type", "text", "text/css")
                .WithProperty("rel", "text")
                .WithProperty("href", "text")
                .WithProperty("cache-buster", "text")
                .WithProperty("media", "text")
                .WithProperty("ie-condition", "text");

            this.Configure.Atom("html-script")
                .WithView("HtmlScript")
                .WithProperty("src", "text")
                .WithProperty("type", "html-script-type", "text/javascript")
                .WithProperty("content", "text")
                .WithProperty("cache-buster", "text")
                .WithProperty("ie-condition", "text");
        }

        private void ConfigureContainers()
        {
            this.Configure.Container("html-head")
                .WithView("HtmlHead");

            this.Configure.Container("html-body")
                .WithView("HtmlBody")
                .WithProperty("classes", "text");

            this.Configure.Container("anchor")
                .WithView("Anchor")
                .WithProperty("href", "text")
                .WithProperty("target", "anchor-target");
        }

        private void ConfigurePropertyTypes()
        {
            this.Configure.PropertyType("markdown")
                .WithEditor("MarkdownEditorView.js");

            this.Configure.PropertyType("boolean")
                .WithEditor("BooleanEditorView.js");

            this.Configure.PropertyType("html-script-type")
                .WithEditor("TextEditorView.js");

            this.Configure.PropertyType("text")
                .WithEditor("TextEditorView.js");

            this.Configure.PropertyType("number")
                .WithEditor("TextEditorView.js");

            this.Configure.PropertyType("anchor-target")
                .WithEditor("TextEditorView.js");
        }
    }
}
