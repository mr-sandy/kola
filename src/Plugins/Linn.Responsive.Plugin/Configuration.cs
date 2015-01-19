namespace Linn.Responsive.Plugin
{
    using Kola.Configuration.Plugins;

    public class Configuration : PluginConfiguration
    {
        public Configuration()
            : base("LinnCore")
        {
            this.Configure.ViewLocation("Linn.Responsive.Plugin.Views");
            this.Configure.EditorStylesheets("editor.css");

            this.Configure.Atom("main-menu")
                .WithView("MainMenu");

            this.Configure.Atom("secondary-nav")
                .WithView("SecondaryNav");

            this.Configure.Container("carousel")
                .WithView("Carousel")
                .WithProperty("alignment", "carousel-alignment")
                .WithProperty("infinity-scroll", "boolean", "false")
                .WithProperty("slide-per-page", "boolean", "false")
                .WithProperty("preview-previous", "number")
                .WithProperty("preview-next", "number")
                .WithProperty("preview-threshold", "number")
                .WithProperty("touch-threshold", "number");

            this.Configure.PropertyType("carousel-alignment")
                .WithEditor("TextEditorView.js");

            this.Configure.PropertyType("placement")
                .WithEditor("TextEditorView.js");
        }
    }
}
