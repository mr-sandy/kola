namespace Kola.Service.Services
{
    using System.Collections.Generic;
    using System.Linq;

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

        public RenderingService(IContentRepository contentRepository, IWidgetSpecificationRepository widgetSpecificationRepository, IComponentSpecificationLibrary componentLibrary)
        {
            this.contentRepository = contentRepository;
            this.widgetSpecificationRepository = widgetSpecificationRepository;
            this.componentLibrary = componentLibrary;
        }

        public IResult<PageInstance> GetPage(IEnumerable<string> path, IEnumerable<KeyValuePair<string, string>> parameters, IUser user, bool preview)
        {
            var results = (this.contentRepository.FindContent(path) ?? Enumerable.Empty<FindContentResult>()).ToArray();

            if (!results.Any())
            {
                var notFoundTemplate = this.contentRepository.GetTemplate(new[] { "404" });
                var notFoundPage = notFoundTemplate == null ? null : this.BuildPage(notFoundTemplate, null, preview);
                return new NotFoundResult<PageInstance>(notFoundPage);
            }

            var result = preview ? results.TakeTemplateResult() : results.FavourRedirectResult();

            var visitor = new ContentVisitor<IResult<PageInstance>>(
                template =>
                    {
                        if (!this.IsAuthorised(user, result))
                        {
                            var customTemplate = this.contentRepository.GetTemplate(new[] { "401" });
                            var customPage = customTemplate == null ? null : this.BuildPage(customTemplate, null, preview);
                            return new UnauthorisedResult<PageInstance>(customPage);
                        }

                        var contextItems = this.ContextItems(parameters, result.Configuration);
                        return new SuccessResult<PageInstance>(this.BuildPage(template, contextItems, preview));
                    },
                redirect => new MovedPermanentlyResult<PageInstance>(redirect.Location));

            return result.Content.Accept(visitor);
        }

        public IResult<ComponentInstance> GetFragment(IEnumerable<string> path, IEnumerable<KeyValuePair<string, string>> parameters, IUser user, IEnumerable<int> componentPath)
        {
            var result = this.contentRepository.FindContent(path).TakeTemplateResult();

            if (result == null)
            {
                return new NotFoundResult<ComponentInstance>();
            }

            if (!this.IsAuthorised(user, result))
            {
                return new UnauthorisedResult<ComponentInstance>();
            }

            var contextItems = this.ContextItems(parameters, result.Configuration);
            var page = this.BuildPage(result.Content as Template, contextItems, true);

            var finder = new ComponentFindingComponentInstanceVisitor();

            var fragment = finder.Find(page, componentPath);

            return new SuccessResult<ComponentInstance>(fragment);
        }

        private bool IsAuthorised(IUser user, FindContentResult result)
        {
            return result.Configuration?.Conditions == null || !result.Configuration.Conditions.Any() || result.Configuration.Conditions.All(a => a.Test(user));
        }

        private IEnumerable<IContextItem> ContextItems(IEnumerable<KeyValuePair<string, string>> parameters, IConfiguration config)
        {
            var parameterContext = parameters?.Select(p => p.ToContextItem()) ?? Enumerable.Empty<IContextItem>();
            var configContext = config?.ContextItems ?? Enumerable.Empty<IContextItem>();
            return parameterContext.Union(configContext);
        }

        private PageInstance BuildPage(Template template, IEnumerable<IContextItem> contextItems, bool isPreview)
        {
            // TODO {SC} Decide if I really want to do this...
            if (isPreview)
            {
                template.ApplyAmendments(this.componentLibrary);
            }

            var buildContext = new BuildSettings(contextItems ?? Enumerable.Empty<IContextItem>());

            var builder = new Builder(new RenderingInstructions(isPreview), this.widgetSpecificationRepository.Find, this.componentLibrary);

            return builder.Build(template, buildContext);
        }

    }
}
