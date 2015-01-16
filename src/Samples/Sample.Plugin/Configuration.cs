namespace Sample.Plugin
{
    using Kola.Configuration.Plugins;

    using Sample.Plugin.Renderers;

    public class Configuration : PluginConfiguration
    {
        public Configuration()
            : base("Sample")
        {
            this.Configure.ViewLocation("Sample.Plugin.Views");

            this.Configure.Atom("atom-1")
                .WithRenderer<Atom1Renderer>()
                .Cache.For(100);

            this.Configure.Atom("atom-2")
                .WithView("Atom2")
                .WithProperty("property-name-1", "property-type-1")
                .WithProperty("property-name-2", "property-type-2")
                .Cache.Cache.For(100);

            this.Configure.Container("container-1")
                .WithView("Container1")
                .WithProperty("property-name-1", "property-type-1");

            this.Configure.Container("container-2")
                .WithView("Container2");

            this.Configure.PropertyType("property-1")
                .WithEditor("editor?");
        }
    }
}
