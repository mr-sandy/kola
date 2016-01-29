namespace Kola.Nancy.Models
{
    using System.Collections.Generic;
    using System.Linq;

    using Kola.Configuration;

    public class ApplicationModel
    {
        public static ApplicationModel Build(IKolaConfigurationRegistry kolaConfigurationRegistry)
        {
            var editorScripts = kolaConfigurationRegistry.Plugins
                .Where(p => !string.IsNullOrEmpty(p.PropertyEditor))
                .Select(p => $"/_kola/plugins/{p.PluginName}/{p.PropertyEditor}");

            var editorStylesheets = kolaConfigurationRegistry.Plugins
                .Where(p => !string.IsNullOrEmpty(p.PropertyEditorStylesheet))
                .Select(p => $"/_kola/plugins/{p.PluginName}/{p.PropertyEditorStylesheet}");


            return new ApplicationModel(editorScripts, editorStylesheets);
        }

        public ApplicationModel(IEnumerable<string> editorScripts, IEnumerable<string> editorStylesheets)
        {
            this.EditorScripts = editorScripts;
            this.EditorStylesheets = editorStylesheets;
        }
        public IEnumerable<string> EditorScripts { get; }

        public IEnumerable<string> EditorStylesheets { get; }

    }
}