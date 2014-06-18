namespace Kola.Nancy.Modules
{
    using global::Nancy;
    using global::Nancy.Responses.Negotiation;

    public class AdminModule : NancyModule
    {
        public AdminModule()
        {
            this.Get["/_kola"] = this.GetPage;
            this.Get["/_kola/{*}"] = this.GetPage;
        }

        private Negotiator GetPage(dynamic parameters)
        {
            return this.Negotiate
                .WithContentType("text/html")
                .WithView("Admin");
        }
    }
}