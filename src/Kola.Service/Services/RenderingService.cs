namespace Kola.Service.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Claims;

    using Kola.Domain.Composition;
    using Kola.Domain.Instances;
    using Kola.Domain.Instances.Config;
    using Kola.Domain.Rendering;
    using Kola.Persistence;
    using Kola.Persistence.Extensions;
    using Kola.Service.Extensions;
    using Kola.Service.Services.Results;

    public class RenderingService : IRenderingService
    {
        private readonly IContentRepository contentRepository;
        private readonly IWidgetSpecificationRepository widgetSpecificationRepository;
        private readonly IComponentSpecificationLibrary componentLibrary;
        private readonly IPluginContextProvider pluginContextProvider;

        public RenderingService(IContentRepository contentRepository, IWidgetSpecificationRepository widgetSpecificationRepository, IComponentSpecificationLibrary componentLibrary, IPluginContextProvider pluginContextProvider)
        {
            this.contentRepository = contentRepository;
            this.widgetSpecificationRepository = widgetSpecificationRepository;
            this.componentLibrary = componentLibrary;
            this.pluginContextProvider = pluginContextProvider;
        }

        public IResult<PageInstance> GetPage(IEnumerable<string> path, IEnumerable<KeyValuePair<string, string>> parameters, ClaimsPrincipal user, bool preview)
        {
            var results = (this.contentRepository.FindContent(path) ?? Enumerable.Empty<FindContentResult>()).ToArray();

            if (!results.Any())
            {
                var notFoundTemplate = this.contentRepository.GetTemplate(new[] { "404" });
                var notFoundPage = notFoundTemplate == null ? null : this.BuildPage(notFoundTemplate, preview);
                return new NotFoundResult<PageInstance>(notFoundPage);
            }

            var result = preview ? results.TakeTemplateResult() : results.FavourRedirectResult();

            var visitor = new ContentVisitor<IResult<PageInstance>>(
                template =>
                    {
                        if (!result.Configuration.Conditions.SatisfiedBy(user))
                        {
                            return this.CreateFailedAuthResult(user, preview);
                        }

                        var contextItems = this.BuildContext(parameters, result.Configuration);
                        return new SuccessResult<PageInstance>(this.BuildPage(template, preview, contextItems, result.Configuration.CacheControl));
                    },
                redirect => new MovedPermanentlyResult<PageInstance>(redirect.Location));

            return result.Content.Accept(visitor);
        }


        public IResult<ComponentInstance> GetFragment(IEnumerable<string> path, IEnumerable<KeyValuePair<string, string>> parameters, ClaimsPrincipal user, IEnumerable<int> componentPath)
        {
            var result = this.contentRepository.FindContent(path).TakeTemplateResult();

            if (result == null)
            {
                return new NotFoundResult<ComponentInstance>();
            }

            if (!result.Configuration.Conditions.SatisfiedBy(user))
            {
                return user?.Identity != null &&  user.Identity.IsAuthenticated
                           ? (IResult<ComponentInstance>)new ForbiddenResult<ComponentInstance>()
                           : (IResult<ComponentInstance>)new UnauthorisedResult<ComponentInstance>();
            }

            var context = this.BuildContext(parameters, result.Configuration);
            var page = this.BuildPage(result.Content as Template, true, context);

            var finder = new ComponentFindingComponentInstanceVisitor();

            var fragment = finder.Find(page, componentPath);

            return new SuccessResult<ComponentInstance>(fragment);
        }

        private IResult<PageInstance> CreateFailedAuthResult(ClaimsPrincipal user, bool preview)
        {
            if (user?.Identity != null && user.Identity.IsAuthenticated)
            {
                var customTemplate = this.contentRepository.GetTemplate(new[] { "403" });
                var customPage = customTemplate == null ? null : this.BuildPage(customTemplate, preview);
                return new ForbiddenResult<PageInstance>(customPage);
            }
            else
            {
                var customTemplate = this.contentRepository.GetTemplate(new[] { "401" });
                var customPage = customTemplate == null ? null : this.BuildPage(customTemplate, preview);
                return new UnauthorisedResult<PageInstance>(customPage);
            }
        }

        private IEnumerable<IContextItem> BuildContext(IEnumerable<KeyValuePair<string, string>> parameters, IConfiguration config)
        {
            // build any context from the query string and http request 
            var parameterContext = parameters?.Select(p => p.ToContextItem()).ToArray() ?? new IContextItem[] { };

            // build any context from the config files
            var configContext = config?.ContextItems?.ToArray() ?? new IContextItem[] { };

            // build any context from the plugins - they get to see any context generated so far
            var pluginContext  = this.pluginContextProvider.Contribute(parameterContext.Union(configContext)) ?? new IContextItem[] { };

            // squish it all together.  add parameters last so they can overide stuff generated by the plugins
            return configContext.Union(pluginContext).Union(parameterContext).ToArray();
        }

        private PageInstance BuildPage(Template template, bool isPreview, IEnumerable<IContextItem> contextItems = null, string cacheControl = null)
        {
            if (isPreview)
            {
                template.ApplyAmendments(this.componentLibrary);
            }

            var renderingInstructions = isPreview 
                ? RenderingInstructions.BuildForPreview() 
                : RenderingInstructions.Build(cacheControl);

            var builder = new Builder(renderingInstructions, this.widgetSpecificationRepository.Find, this.componentLibrary);

            return builder.Build(template, new BuildData(contextItems));
        }
    }
}
