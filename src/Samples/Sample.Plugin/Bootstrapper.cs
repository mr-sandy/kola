using Kola.Configuration.Plugins;
using Sample.Plugin.Handlers;

namespace Sample.Plugin
{
    public class Bootstrapper : PluginBootstrapper
    {
        public Bootstrapper()
        {
            this.Configure.ViewLocation("Sample.Plugin.Views");

            this.Configure.Atom("atom-1")
                .WithHandler<Atom1Handler>()
                .Cache.For(100);

            this.Configure.Atom("atom-2")
                .WithView("Atom2")
                .WithParameter("parameter-name-1", "parameter-type-1", "parameter-value-1")
                .WithParameter("parameter-name-2", "parameter-type-2")
                .Cache.PerUser.For(100);

            this.Configure.Container("container-1")
                .WithView("Container1")
                .WithParameter("parameter-name-1", "parameter-type-1", "parameter-value-1");

            this.Configure.ParameterType("parameter-1")
                .DefaultTo("default")
                .WithEditor("editor?");
        }
    }
}
