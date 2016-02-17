namespace Kola.Nancy.Modules
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;

    using global::Nancy;
    using global::Nancy.ModelBinding;
    using global::Nancy.Security;

    using Kola.Nancy.Extensions;
    using Kola.Nancy.Models;
    using Kola.Service.Services;

    public class RenderingModule : NancyModule
    {
        private readonly IRenderingService renderingService;

        public RenderingModule(IRenderingService renderingService)
        {
            this.renderingService = renderingService;
            this.Get["/"] = this.GetResponse;
            this.Get["/(.*)"] = this.GetResponse;
            this.Get["/{path*}"] = this.GetResponse;
        }

        [SuppressMessage("StyleCop.CSharp.NamingRules", "SA1309:FieldNamesMustNotBeginWithUnderscore",
            Justification = "Reviewed. Suppression is OK here.")]
        private dynamic GetResponse(dynamic _)
        {
            var query = this.Bind<RenderQuery>();
            var path = this.Request.Path.ParsePath();
            var parameters = this.GetQueryParameters("preview", "ComponentPath");

            return string.IsNullOrEmpty(query.ComponentPath)
                       ? this.GetPage(path, parameters, query.IsPreview)
                       : this.GetFragment(path, parameters, query.ComponentPath.ParseComponentPath());
        }

        private IEnumerable<KeyValuePair<string, string>> GetQueryParameters(params string[] exclusions)
        {
            var parsed = this.Request.Url.Query.Split('?', '&')
                .Where(str => str.IndexOf("=", StringComparison.Ordinal) > -1)
                .Select(
                    o =>
                        {
                            var split = o.Split('=');
                            return new KeyValuePair<string, string>(split[0], split[1]);
                        }).Where(p => !exclusions.Contains(p.Key));

            return new List<KeyValuePair<string, string>>(parsed)
                       {
                           new KeyValuePair<string, string>(
                               "raw-query",
                               this.Request.Url.Query)
                       };
        }

        private dynamic GetPage(
            IEnumerable<string> path,
            IEnumerable<KeyValuePair<string, string>> parameters,
            bool preview)
        {
            var result = this.renderingService.GetPage(path, parameters, this.Context.GetMSOwinUser(), preview);

            return this.Negotiate.WithModel(result);
        }

        private dynamic GetFragment(
            IEnumerable<string> path,
            IEnumerable<KeyValuePair<string, string>> parameters,
            IEnumerable<int> componentPath)
        {
            var result = this.renderingService.GetFragment(
                path,
                parameters,
                this.Context.GetMSOwinUser(),
                componentPath);

            return this.Negotiate.WithModel(result);
        }
    }
}