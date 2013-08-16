using Nancy;
using Nancy.Responses.Negotiation;

namespace Kola.Nancy.Modules
{
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