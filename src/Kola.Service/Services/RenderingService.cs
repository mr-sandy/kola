namespace Kola.Service.Services
{
    using System.Collections.Generic;
    using System.Linq;

    using Kola.Domain.Composition;
    using Kola.Domain.Instances;
    using Kola.Domain.Instances.Context;
    using Kola.Domain.Rendering;
    using Kola.Persistence;
    using Kola.Persistence.Extensions;
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

        public IResult<PageInstance> GetPage(IEnumerable<string> path, bool preview, IUser user)
        {
            var results = (this.contentRepository.FindContent(path) ?? Enumerable.Empty<FindContentResult>()).ToArray();

            if (!results.Any())
            {
                return new NotFoundResult<PageInstance>();
            }

            var result = preview ? results.TakeTemplateResult() : results.FavourRedirectResult();

            var visitor = new ContentVisitor<IResult<PageInstance>>(
                template =>
                    {
                        if (result.Context?.AuthChecks != null && result.Context.AuthChecks.Any() && !result.Context.AuthChecks.All(a => a.Test(user)))
                        {
                            return new UnauthorisedResult<PageInstance>();
                        }

                        return new SuccessResult<PageInstance>(this.BuildPage(template, result.Context?.ContextItems, preview));
                    },
                redirect => new MovedPermanentlyResult<PageInstance>(redirect.Location));

            return result.Content.Accept(visitor);
        }

        public IResult<ComponentInstance> GetFragment(IEnumerable<string> path, IEnumerable<int> componentPath)
        {
            var result = this.contentRepository.FindContent(path).TakeTemplateResult();

            if (result == null)
            {
                return new NotFoundResult<ComponentInstance>();
            }

            var page = this.BuildPage(result.Content as Template, result.Context?.ContextItems, true);

            var finder = new ComponentFindingComponentInstanceVisitor();

            var fragment = finder.Find(page, componentPath);

            return new SuccessResult<ComponentInstance>(fragment);
        }

        private PageInstance BuildPage(Template template, IEnumerable<IContextItem> contextItems, bool preview)
        {
            template.ApplyAmendments(this.componentLibrary);

            var buildContext = new BuildContext();

            if (contextItems != null && contextItems.Any())
            {
                buildContext.ContextSets.Push(new ContextSet(contextItems));
            }

            var builder = new Builder(new RenderingInstructions(useCache: !preview, annotateComponentPaths: preview), this.widgetSpecificationRepository.Find);

            return builder.Build(template, buildContext);
        }
    }


}
