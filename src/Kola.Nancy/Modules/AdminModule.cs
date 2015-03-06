namespace Kola.Nancy.Modules
{
    using System.Linq;

    using Kola.Configuration;

    using global::Nancy;
    using global::Nancy.Json;
    using global::Nancy.Responses.Negotiation;

    using Kola.Nancy.Extensions;

    public class AdminModule : NancyModule
    {
        private readonly IKolaConfigurationRegistry kolaConfigurationRegistry;

        public AdminModule(IKolaConfigurationRegistry kolaConfigurationRegistry)
        {
            this.kolaConfigurationRegistry = kolaConfigurationRegistry;

            this.Get["/_kola", AcceptHeaderFilters.Html] = this.GetPage;
            this.Get["/_kola/{*}", AcceptHeaderFilters.Html] = this.GetPage;
        }

        private Negotiator GetPage(dynamic properties)
        {
            var serialiser = new JavaScriptSerializer();

            var propertyEditors = from plugin in this.kolaConfigurationRegistry.KolaConfiguration.Plugins
                                  from property in plugin.PropertyTypeSpecifications
                                  select new { name = property.Name, url = string.Format("/_kola/editors/{0}/views/{1}", plugin.PluginName.Urlify(), property.EditorName) };

            var editorStylesheets = from plugin in this.kolaConfigurationRegistry.KolaConfiguration.Plugins
                                    from stylesheet in plugin.EditorStylesheets
                                    select string.Format("/_kola/editors/{0}/css/{1}", plugin.PluginName.Urlify(), stylesheet);
            var model = new
                {
                    PropertyEditors = serialiser.Serialize(propertyEditors),
                    EditorStylesheets = editorStylesheets
                };

            return this.Negotiate
                .WithModel(model)
                .WithAllowedMediaRange("text/html")
                .WithView("Admin");
        }
    }
}