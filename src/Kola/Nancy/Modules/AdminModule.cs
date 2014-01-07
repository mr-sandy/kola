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
        }

        private Negotiator GetPage(dynamic parameters)
        {
            return View["Admin"];
        }
    }
}