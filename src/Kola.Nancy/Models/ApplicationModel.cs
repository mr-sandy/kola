namespace Kola.Nancy.Models
{
    using System.Collections.Generic;
    using System.Linq;

    using global::Nancy.Json;

    using Kola.Configuration;
    using Kola.Nancy.Extensions;

    public class ApplicationModel
    {
        public static ApplicationModel Build(IKolaConfigurationRegistry kolaConfigurationRegistry)
        {
            var propertyEditors = from plugin in kolaConfigurationRegistry.KolaConfiguration.Plugins
                                  from property in plugin.PropertyTypeSpecifications
                                  select new
                                  {
                                      name = property.Name,
                                      url = $"/_kola/editors/{plugin.PluginName.Urlify()}/views/{property.EditorName}"
                                  };

            var editorStylesheets = from plugin in kolaConfigurationRegistry.KolaConfiguration.Plugins
                                    from stylesheet in plugin.EditorStylesheets
                                    select $"/_kola/editors/{plugin.PluginName.Urlify()}/css/{stylesheet}";

            return new ApplicationModel(new JavaScriptSerializer().Serialize(propertyEditors), editorStylesheets);
        }

        public ApplicationModel(string propertyEditors, IEnumerable<string> editorStylesheets)
        {
            this.PropertyEditors = propertyEditors;
            this.EditorStylesheets = editorStylesheets;
        }

        public string PropertyEditors { get; }

        public IEnumerable<string> EditorStylesheets { get; }
    }
}