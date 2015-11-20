namespace Kola.Service.Services
{
    using System.Collections.Generic;

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

        public IResult<PageInstance> GetPage(IEnumerable<string> path, bool preview)
        {
            var contents = this.contentRepository.FindContents(path);
            var content = preview 
                ? contents.TakeTemplate() 
                : contents.TakeRedirectElseTemplate();

            if (content == null)
            {
                return new NotFoundResult<PageInstance>();
            }

            var visitor = new ContentVisitor<IResult<PageInstance>>(
                template =>
                {
                    var page = this.BuildPage(template, this.GetRenderingInstructions(preview));

                    return new SuccessResult<PageInstance>(page);
                },
                redirect => new MovedPermanentlyResult<PageInstance>(redirect.Location));

            return content.Accept(visitor);
        }


        public IResult<ComponentInstance> GetFragment(IEnumerable<string> path, IEnumerable<int> componentPath)
        {
            var template = this.contentRepository.FindContents(path).TakeTemplate();

            if (template == null)
            {
                return new NotFoundResult<ComponentInstance>();
            }

            var page = this.BuildPage(template, this.GetRenderingInstructions(true));

            var finder = new ComponentFindingComponentInstanceVisitor();

            var fragment = finder.Find(page, componentPath);

            return new SuccessResult<ComponentInstance>(fragment);
        }

        private PageInstance BuildPage(Template template, IRenderingInstructions renderingInstructions)
        {
            template.ApplyAmendments(this.componentLibrary);

            var buildContext = new BuildContext { WidgetSpecificationFinder = n => this.widgetSpecificationRepository.Find(n) };

            var builder = new Builder(renderingInstructions);

            return builder.Build(template, buildContext);
        }

        private IRenderingInstructions GetRenderingInstructions(bool preview)
        {
            return new RenderingInstructions(useCache: !preview, annotateComponentPaths: preview);
        }
    }
}