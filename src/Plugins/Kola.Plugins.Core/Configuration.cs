namespace Kola.Plugins.Core
{
    using Kola.Configuration.Plugins;
    using Kola.Plugins.Core.Renderers;

    public class Configuration : PluginConfiguration
    {
        public Configuration()
            : base("KolaCore")
        {
            this.Configure.ViewLocation("Kola.Plugins.Core.Views");
            this.Configure.PropertyEditorStylesheets("css/editor.min.css");
            this.Configure.PropertyEditor("scripts/editor.js");

            this.ConfigureAtoms();

            this.ConfigureContainers();
        }

        private void ConfigureAtoms()
        {
            this.Configure.Atom("markdown")
                .WithCategory("core")
                .WithRenderer<MarkdownRenderer>()
                .WithProperty("markdown", "markdown", "*add content here*");

            this.Configure.Atom("label")
                .WithCategory("core")
                .WithView("Label")
                .WithProperty("caption", "text");

            this.Configure.Atom("text")
                .WithCategory("core")
                .WithView("Text")
                .WithProperty("text", "text");

            this.Configure.Atom("html-title")
                .WithCategory("html")
                .WithView("HtmlTitle")
                .WithProperty("title", "text");

            this.Configure.Atom("html-metadata")
                .WithCategory("html")
                .WithView("HtmlMetadata")
                .WithProperty("name", "text")
                .WithProperty("content", "text")
                .WithProperty("charset", "text")
                .WithProperty("httpEquiv", "text");

            this.Configure.Atom("html-style")
                .WithCategory("html")
                .WithView("HtmlStyle")
                .WithProperty("type", "html-style-type", "text/css")
                .WithProperty("content", "multiline-text")
                .WithProperty("media", "text");

            this.Configure.Atom("html-link")
                .WithCategory("core")
                .WithView("HtmlLink")
                .WithProperty("type", "html-link-type")
                .WithProperty("rel", "html-link-rel-type")
                .WithProperty("href", "text")
                .WithProperty("sizes", "text")
                .WithProperty("cache-buster", "text")
                .WithProperty("ie-condition", "ie-condition")
                .WithProperty("media", "text");

            this.Configure.Atom("html-script")
                .WithCategory("html")
                .WithView("HtmlScript")
                .WithProperty("type", "html-script-type", "text/javascript")
                .WithProperty("id", "text")
                .WithProperty("src", "text")
                .WithProperty("content", "multiline-text")
                .WithProperty("ie-condition", "ie-condition")
                .WithProperty("cache-buster", "text");

            this.Configure.Atom("magical-atom")
                .WithCategory("core")
                .WithView("Text")
                .WithProperty("markdown", "markdown")
                .WithProperty("boolean", "boolean")
                .WithProperty("text", "text")
                .WithProperty("number", "number")
                .WithProperty("html-link-type", "html-link-type")
                .WithProperty("html-link-rel-type", "html-link-rel-type")
                .WithProperty("html-style-type", "html-style-type")
                .WithProperty("html-script-type", "html-script-type")
                .WithProperty("multiline-text", "multiline-text")
                .WithProperty("ie-condition", "ie-condition");
        }

        private void ConfigureContainers()
        {
            this.Configure.Container("html-head")
                .WithCategory("html")
                .WithView("HtmlHead");

            this.Configure.Container("html-body")
                .WithCategory("html")
                .WithView("HtmlBody")
                .WithProperty("classes", "text");
        }
    }
}