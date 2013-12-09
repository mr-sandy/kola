namespace Sample.Plugin
{
    using Kola.Configuration;

    using Sample.Plugin.Handlers;

    public class Configuration : PluginConfiguration
    {
        public Configuration()
        {
            this.Configure.ViewLocation("Sample.Plugin.Views");

            this.Configure.Component("atom-1")
                .WithHandler<Atom1Handler>()
                .Cache.For(100);

            this.Configure.Component("atom-2")
                .WithView("Atom2")
                .WithParameter("parameter-name-1", "parameter-type-1", "parameter-value-1")
                .WithParameter("parameter-name-2", "parameter-type-2")
                .Cache.PerUser.For(100);

            this.Configure.Component("container-1")
                .WithView("Container1")
                .WithParameter("parameter-name-1", "parameter-type-1", "parameter-value-1");

            this.Configure.ParameterType("parameter-1")
                .WithDefault("default")
                .WithEditor("editor?");
        }
    }
}
