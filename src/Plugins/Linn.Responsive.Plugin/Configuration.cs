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
            this.Configure.Atom("image")
                .WithView("Image")
                .WithProperty("src", "text")
                .WithProperty("alt", "text")
                .WithProperty("height", "height")
                .WithProperty("width", "width")
                .WithProperty("margin", "margin")
                .WithProperty("grid-placement", "grid-placement");

            this.Configure.Atom("main-menu")
                .WithView("MainMenu");

            this.Configure.Atom("secondary-nav")
                .WithView("SecondaryNav");

            this.Configure.Atom("pager")
                .WithView("Pager")
                .WithProperty("content-set-id", "text");

            this.Configure.Atom("icon")
                .WithView("Icon")
                .WithProperty("icon", "icon")
                .WithProperty("margin", "margin");
        }

        private void ConfigureContainers()
        {
            this.Configure.Container("carousel")
                .WithView("Carousel")
                .WithProperty("content-set-id", "text")
                .WithProperty("alignment", "text")
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
                .WithProperty("is-slide", "boolean")
                .WithProperty("id", "text")
                .WithProperty("style", "text")
                .WithProperty("show-grids", "text")
                .WithProperty("shadow", "shadow")
                .ExtendWith(this.CommonProperties);

            this.Configure.Container("division")
                .WithView("Division")
                .WithProperty("is-slide", "boolean")
                .WithProperty("triangle", "triangle")
                .WithProperty("content-id", "text")
                .WithProperty("text-alignment", "text-alignment")
                .WithProperty("show-grids", "text")
                .WithProperty("min-height", "height")
                .WithProperty("max-height", "height")
                .WithProperty("min-width", "width")
                .WithProperty("max-width", "width")
                .WithProperty("shadow", "shadow")
                .ExtendWith(this.CommonProperties);

            this.Configure.Container("navigation")
                .WithView("Navigation")
                .WithProperty("navigation-type", "text")
                .ExtendWith(this.CommonProperties);

            this.Configure.Container("inner")
                .WithView("Inner")
                .WithProperty("inner-type", "inner-type", "[{\"grid\":\"xxl\",\"type\":\"full\"}]")
                .WithProperty("show-grids", "text");

            this.Configure.Container("figure")
                .WithView("Figure")
                .WithProperty("is-slide", "boolean")
                .WithProperty("grid-placement", "text")
                .WithProperty("content-id", "text")
                .WithProperty("text-alignment", "text-alignment")
                .WithProperty("height", "height")
                .WithProperty("width", "width")
                .WithProperty("padding", "padding");

            this.Configure.Container("figure-caption")
                .WithView("FigureCaption")
                .WithProperty("pointer-up", "boolean")
                .ExtendWith(this.CommonProperties);

            this.Configure.Container("aside")
                .WithView("Aside")
                .ExtendWith(this.CommonProperties);

            this.Configure.Container("button")
                .WithView("Button")
                .WithProperty("button-style", "button-style")
                .ExtendWith(this.CommonProperties);

            this.Configure.Container("anchor")
                .WithView("Anchor")
                .WithProperty("href", "text")
                .WithProperty("target", "text")
                .WithProperty("triangle", "triangle")
                .WithProperty("text-alignment", "text-alignment")
                .WithProperty("min-height", "height")
                .WithProperty("max-height", "height")
                .WithProperty("min-width", "width")
                .WithProperty("max-width", "width")
                .ExtendWith(this.CommonProperties);
        }

        private void ConfigurePropertyTypes()
        {
            this.Configure.PropertyType("grid-placement")
                .WithEditor("GridPlacementView.js");

            this.Configure.PropertyType("float")
                .WithEditor("FloatView.js");

            this.Configure.PropertyType("responsive-colour")
                .WithEditor("ResponsiveColourView.js");

            this.Configure.PropertyType("colour")
                .WithEditor("ColourView.js");

            this.Configure.PropertyType("triangle")
                .WithEditor("TriangleView.js");

            this.Configure.PropertyType("text-alignment")
                .WithEditor("TextAlignmentView.js");

            this.Configure.PropertyType("padding")
                .WithEditor("PaddingView.js");

            this.Configure.PropertyType("margin")
                .WithEditor("MarginView.js");

            this.Configure.PropertyType("border-style")
                .WithEditor("BorderStyleView.js");

            this.Configure.PropertyType("position")
                .WithEditor("PositionView.js");

            this.Configure.PropertyType("height")
                .WithEditor("HeightView.js");

            this.Configure.PropertyType("width")
                .WithEditor("WidthView.js");

            this.Configure.PropertyType("icon")
                .WithEditor("IconView.js");

            this.Configure.PropertyType("button-style")
                .WithEditor("ButtonStyleView.js");

            this.Configure.PropertyType("font")
                .WithEditor("FontView.js");

            this.Configure.PropertyType("inner-type")
                .WithEditor("InnerTypeView.js");

            this.Configure.PropertyType("shadow")
                .WithEditor("ShadowView.js");
        }

        private void CommonProperties(ComponentRendererConfigurer configureComponent)
        {
            configureComponent
                .WithProperty("grid-placement", "grid-placement")
                .WithProperty("float", "float")
                .WithProperty("margin", "margin")
                .WithProperty("padding", "padding")
                .WithProperty("border-style", "border-style")
                .WithProperty("border-colour", "responsive-colour")
                .WithProperty("background-colour", "responsive-colour")
                .WithProperty("background-colour-hover", "responsive-colour")
                .WithProperty("text-colour", "responsive-colour")
                .WithProperty("text-colour-hover", "responsive-colour")
                .WithProperty("position", "position")
                .WithProperty("width", "width")
                .WithProperty("height", "height")
                .WithProperty("font", "font");
        }
    }
}
