namespace Kola.Nancy.Modules
{
    using System.Linq;

    using Kola.ResourceBuilding;
    using Kola.Service;

    using global::Nancy;
    using global::Nancy.Json;
    using global::Nancy.Responses.Negotiation;

    public class AdminModule : NancyModule
    {
        private readonly ParameterSpecificationLibrary parameterSpecificationLibrary;

        public AdminModule(ParameterSpecificationLibrary parameterSpecificationLibrary)
        {
            this.parameterSpecificationLibrary = parameterSpecificationLibrary;

            this.Get["/_kola", AcceptHeaderFilters.Html] = this.GetPage;
            this.Get["/_kola/{*}", AcceptHeaderFilters.Html] = this.GetPage;
        }

        private Negotiator GetPage(dynamic parameters)
        {
            var serialiser = new JavaScriptSerializer();

            var parameterEditors = this.parameterSpecificationLibrary.FindAll().Select(p => new { name = p.Name, url = "/_kola/editors/views/" + p.EditorName });

            //var resource = new ParameterTypeResourceBuilder().Build(parameterEditors);

            var model = new
                {
                    ParameterEditors = serialiser.Serialize(parameterEditors)
                };

            return this.Negotiate
                .WithModel(model)
                .WithAllowedMediaRange("text/html")
                .WithView("Admin");
        }
    }
}