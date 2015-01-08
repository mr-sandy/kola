namespace Kola.Nancy.Modules
{
    using System.Linq;

    using Kola.Service;

    using global::Nancy;
    using global::Nancy.Json;
    using global::Nancy.Responses.Negotiation;

    public class AdminModule : NancyModule
    {
        private readonly PropertySpecificationLibrary propertySpecificationLibrary;

        public AdminModule(PropertySpecificationLibrary propertySpecificationLibrary)
        {
            this.propertySpecificationLibrary = propertySpecificationLibrary;

            this.Get["/_kola", AcceptHeaderFilters.Html] = this.GetPage;
            this.Get["/_kola/{*}", AcceptHeaderFilters.Html] = this.GetPage;
        }

        private Negotiator GetPage(dynamic properties)
        {
            var serialiser = new JavaScriptSerializer();

            var propertyEditors = this.propertySpecificationLibrary.FindAll().Select(p => new { name = p.Name, url = "/_kola/editors/views/" + p.EditorName });

            var model = new
                {
                    PropertyEditors = serialiser.Serialize(propertyEditors)
                };

            return this.Negotiate
                .WithModel(model)
                .WithAllowedMediaRange("text/html")
                .WithView("Admin");
        }
    }
}