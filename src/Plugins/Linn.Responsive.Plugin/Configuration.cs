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
        }

        private void ConfigureContainers()
        {
            this.Configure.Container("carousel")
                .WithView("Carousel")
                .WithProperty("alignment", "carousel-alignment")
                .WithProperty("infinity-scroll", "boolean", "false")
                .WithProperty("slide-per-page", "boolean", "false")
                .WithProperty("preview-previous", "number")
                .WithProperty("preview-next", "number")
                .WithProperty("preview-threshold", "number")
                .WithProperty("touch-threshold", "number")
                .ExtendWith(this.CommonProperties);

            this.Configure.Container("slide")
                .WithView("Slide")
                .WithProperty("padding", "padding");
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
        }

        private void CommonProperties(ComponentRendererConfigurer configureComponent)
        {
            configureComponent
                .WithProperty("grid-placement", "placement")
                .WithProperty("padding", "padding")
                .WithProperty("height", "height");
        }
    }
}
