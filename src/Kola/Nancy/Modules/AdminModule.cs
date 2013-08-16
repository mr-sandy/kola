using System;
using Nancy;
using Nancy.Responses.Negotiation;

namespace Kola.Nancy.Modules
{
    public class AdminModule : NancyModule
    {
        public AdminModule()
        {
            this.Get["/~"] = this.GetPage;
            this.Get["/~/{*}"] = this.GetPage;
        }

        private Negotiator GetPage(dynamic parameters)
        {
            return View["Admin"];
            //return this.Negotiate
            //.WithMediaRangeModel("text/html", new { Jam = "Jam"}).WithView("Admin");

        }
    }
}