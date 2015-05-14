namespace Kola.Nancy.Modules
{
    using System;
    using System.Linq;

    using global::Nancy;

    internal static class AcceptHeaderFilters
    {
        public static Func<NancyContext, bool> Html
        {
            get { return c => !c.Request.Headers.Accept.Any() || c.Request.Headers.Accept.Count(h => h.Item1 == "text/html") > 0; }
        }

        public static Func<NancyContext, bool> NotHtml
        {
            get { return c => c.Request.Headers.Accept.Any() && c.Request.Headers.Accept.Count(h => h.Item1 == "text/html") == 0; }
        }
    }
}