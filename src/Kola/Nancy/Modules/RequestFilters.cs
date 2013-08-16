using System;
using System.Linq;
using Nancy;

namespace Kola.Nancy.Modules
{
    internal static class AcceptHeaderFilters
    {
        public static Func<NancyContext, bool> Html = c => c.Request.Headers.Accept.Count(h => h.Item1 == "text/html") > 0;

        public static Func<NancyContext, bool> NotHtml = c => c.Request.Headers.Accept.Count(h => h.Item1 == "text/html") == 0;
    }
}