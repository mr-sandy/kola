namespace Sample.Bootstrap.Plugin
{
    using Kola.Configuration.Plugins;

    using Sample.Bootstrap.Plugin.Renderers;

    public class Configuration : PluginConfiguration
    {
        public Configuration()
            : base("Bootstrap")
        {
            this.Configure.ViewLocation("Sample.Bootstrap.Plugin");

            this.Configure.Atom("button")
                .WithRenderer<ButtonRenderer>()
                .WithProperty("caption", "text");
        }
    }
}
