namespace Linn.Responsive.Plugin
{
    using Kola.Configuration.Fluent;
    using Kola.Configuration.Plugins;

    public class Configuration : PluginConfiguration
    {
        public Configuration()
            : base("LinnCore")
        {
            this.Configure.ViewLocation("Linn.Responsive.Plugin.Views");
            this.Configure.EditorStylesheets("editor.css");

            this.ConfigureAtoms();

            this.ConfigureContainers();

            this.ConfigurePropertyTypes();
        }

        private void ConfigureAtoms()
        {
            this.Configure.Atom("main-menu")
                .WithView("MainMenu");

            this.Configure.Atom("secondary-nav")
                .WithView("SecondaryNav");

            this.Configure.Atom("pager")
                .WithView("Pager")
                .WithProperty("content-set-id", "text");
        }

        private void ConfigureContainers()
        {
            this.Configure.Container("carousel")
                .WithView("Carousel")
                .WithProperty("content-set-id", "text")
                .WithProperty("alignment", "carousel-alignment")
                .WithProperty("infinity-scroll", "boolean", "false")
                .WithProperty("slide-per-page", "boolean", "false")
                .WithProperty("show-next", "boolean", "true")
                .WithProperty("show-previous", "boolean", "true")
                .WithProperty("update-hash", "boolean")
                .WithProperty("content-switch", "boolean")
                .WithProperty("preview-previous", "number")
                .WithProperty("preview-next", "number")
                .WithProperty("preview-threshold", "number")
                .WithProperty("touch-threshold", "number")
                .ExtendWith(this.CommonProperties);

            this.Configure.Container("section")
                .WithView("Section")
                .WithProperty("is-slide", "boolean");

            this.Configure.Container("division")
                .WithView("Division")
                .WithProperty("is-slide", "boolean")
                .WithProperty("content-id", "text")
                .ExtendWith(this.CommonProperties);

            this.Configure.Container("figure")
                .WithView("Figure")
                .WithProperty("is-slide", "boolean")
                .WithProperty("content-id", "text")
                .WithProperty("padding", "padding");

            this.Configure.Container("figure-caption")
                .WithView("FigureCaption")
                .WithProperty("pointer-up", "boolean")
                .ExtendWith(this.CommonProperties);
        }

        private void ConfigurePropertyTypes()
        {
            this.Configure.PropertyType("carousel-alignment")
                .WithEditor("TextEditorView.js");

            this.Configure.PropertyType("placement")
                .WithEditor("TextEditorView.js");

            this.Configure.PropertyType("height")
                .WithEditor("TextEditorView.js");

            this.Configure.PropertyType("padding")
                .WithEditor("TextEditorView.js");

            this.Configure.PropertyType("margin")
                .WithEditor("TextEditorView.js");
        }

        private void CommonProperties(ComponentRendererConfigurer configureComponent)
        {
            configureComponent
                .WithProperty("grid-placement", "placement")
                .WithProperty("margin", "margin")
                .WithProperty("padding", "padding")
                .WithProperty("height", "height");
        }
    }
}
