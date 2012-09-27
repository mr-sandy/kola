using Kola.Configuration;
using Sample.Plugin.Handlers;

namespace Sample.Plugin
{
    public class Bootstrapper : PluginBootstrapper
    {
        public override void Configure(PluginConfiguration configuration)
        {
            configuration.SetViewLocation("Sample.Plugin.Views");

            configuration.Register.Atom("atom-1")
                .WithHandler<Atom1Handler>()
                .Cache.For(100);

            configuration.Register.Atom("atom-2")
                .WithView("Atom2")
                .WithParameter("parameter-name-1", "parameter-type-1", "parameter-value-1")
                .WithParameter("parameter-name-2", "parameter-type-2")
                .Cache.PerUser.For(100);

            configuration.Register.Container("container-1")
                .WithView("Container1")
                .Cache.For(20000);

            configuration.Register.ParameterType("parameter-1")
                .DefaultTo("default")
                .WithEditor("editor?");
        }
    }
}
