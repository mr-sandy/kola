namespace Kola.Nancy.Modules
{
    using global::Nancy;
    using global::Nancy.Responses.Negotiation;

    public class AdminModule : NancyModule
    {
        public AdminModule()
        {
            this.Get["/_kola", AcceptHeaderFilters.Html] = this.GetPage;
            this.Get["/_kola/{*}", AcceptHeaderFilters.Html] = this.GetPage;

            this.Get["/_kola2", AcceptHeaderFilters.Html] = this.GetPage2;
            this.Get["/_kola2/{*}", AcceptHeaderFilters.Html] = this.GetPage2;
        }

        private Negotiator GetPage(dynamic parameters)
        {
            return this.Negotiate
                .WithAllowedMediaRange("text/html")
                .WithView("Admin");
        }

        private Negotiator GetPage2(dynamic parameters)
        {
            return this.Negotiate
                .WithAllowedMediaRange("text/html")
                .WithView("Admin2");
        }
    }
}