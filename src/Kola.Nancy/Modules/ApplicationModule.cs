namespace Kola.Nancy.Modules
{
    using global::Nancy;

    using Kola.Configuration;
    using Kola.Nancy.Models;

    public class ApplicationModule : NancyModule
    {
        private readonly IKolaConfigurationRegistry kolaConfigurationRegistry;

        public ApplicationModule(IKolaConfigurationRegistry kolaConfigurationRegistry)
        {
            this.kolaConfigurationRegistry = kolaConfigurationRegistry;
            this.Get["/_kola"] = p => this.GetApplication();
            this.Get["/_kola/templates"] = p => this.GetApplication();
        }

        private dynamic GetApplication()
        {
            return this.Negotiate
                .WithModel(ApplicationModel.Build(this.kolaConfigurationRegistry))
                .WithView("Application");
        }
    }
}