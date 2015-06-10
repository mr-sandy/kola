﻿namespace Kola.Plugins.Core
{
    using Kola.Configuration.Plugins;
    using Kola.Plugins.Core.Renderers;

    public class Configuration : PluginConfiguration
    {
        public Configuration()
            : base("KolaCore")
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

            this.Configure.Atom("text")
                .WithView("Text")
                .WithProperty("text", "text");

            this.Configure.Atom("html-title")
                .WithView("HtmlTitle")
                .WithProperty("title", "text");

            this.Configure.Atom("html-metadata")
                .WithView("HtmlMetadata")
                .WithProperty("name", "text")
                .WithProperty("content", "text")
                .WithProperty("charset", "text")
                .WithProperty("httpEquiv", "text");

            this.Configure.Atom("html-style")
                .WithView("HtmlStyle")
                .WithProperty("type", "html-style-type")
                .WithProperty("content", "multiline-text")
                .WithProperty("media", "text")
                .WithProperty("cache-buster", "text");

            this.Configure.Atom("html-link")
                .WithView("HtmlLink")
                .WithProperty("type", "html-link-type")
                .WithProperty("rel", "html-link-rel-type")
                .WithProperty("href", "text")
                .WithProperty("sizes", "text")
                .WithProperty("cache-buster", "text")
                .WithProperty("ie-condition", "ie-condition")
                .WithProperty("media", "text");

            this.Configure.Atom("html-script")
                .WithView("HtmlScript")
                .WithProperty("type", "html-script-type", "text/javascript")
                .WithProperty("id", "text")
                .WithProperty("src", "text")
                .WithProperty("content", "multiline-text")
                .WithProperty("ie-condition", "ie-condition")
                .WithProperty("cache-buster", "text");
        }

        private void ConfigureContainers()
        {
            this.Configure.Container("html-head")
                .WithView("HtmlHead");

            this.Configure.Container("html-body")
                .WithView("HtmlBody")
                .WithProperty("classes", "text");
        }

        private void ConfigurePropertyTypes()
        {
            this.Configure.PropertyType("markdown")
                .WithEditor("MarkdownEditorView.js");

            this.Configure.PropertyType("boolean")
                .WithEditor("BooleanEditorView.js");

            this.Configure.PropertyType("text")
                .WithEditor("TextEditorView.js");

            this.Configure.PropertyType("number")
                .WithEditor("NumberEditorView.js");

            this.Configure.PropertyType("html-link-type")
                .WithEditor("HtmlLinkTypeView.js");

            this.Configure.PropertyType("html-link-rel-type")
                .WithEditor("HtmlLinkRelTypeView.js");

            this.Configure.PropertyType("html-style-type")
                .WithEditor("HtmlStyleTypeView.js");

            this.Configure.PropertyType("html-script-type")
                .WithEditor("HtmlScriptTypeView.js");

            this.Configure.PropertyType("multiline-text")
                .WithEditor("MultilineTextView.js");

            this.Configure.PropertyType("ie-condition")
                .WithEditor("IeConditionView.js");
        }
    }
}
