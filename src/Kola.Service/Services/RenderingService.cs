namespace Kola.Service.Services
{
    using System.Collections.Generic;

    using Kola.Domain.Composition;
    using Kola.Domain.Instances;
    using Kola.Domain.Instances.Context;
    using Kola.Domain.Rendering;
    using Kola.Persistence;
    using Kola.Service.Services.Results;

    public class RenderingService : IRenderingService
    {
        private readonly ITemplateRepository templateRepository;
        private readonly IWidgetSpecificationRepository widgetSpecificationRepository;
        private readonly IComponentSpecificationLibrary componentLibrary;

        public RenderingService(ITemplateRepository templateRepository, IWidgetSpecificationRepository widgetSpecificationRepository, IComponentSpecificationLibrary componentLibrary)
        {
            this.templateRepository = templateRepository;
            this.widgetSpecificationRepository = widgetSpecificationRepository;
            this.componentLibrary = componentLibrary;
        }

        public IResult<PageInstance> GetPage(IEnumerable<string> path, RenderingInstructions renderingInstructions)
        {
            var template = this.templateRepository.Get(path);

            if (template == null)
            {
                return new NotFoundResult<PageInstance>();
            }

            var page = this.BuildPage(template, renderingInstructions);

            return new SuccessResult<PageInstance>(page);
        }

        public IResult<ComponentInstance> GetFragment(IEnumerable<string> path, RenderingInstructions renderingInstructions, IEnumerable<int> componentPath)
        {
            var template = this.templateRepository.Get(path);

            if (template == null)
            {
                return new NotFoundResult<ComponentInstance>();
            }

            var page = this.BuildPage(template, renderingInstructions);

            var finder = new ComponentFindingComponentInstanceVisitor();

            var fragment = finder.Find(page, componentPath);

            return new SuccessResult<ComponentInstance>(fragment);
        }

        private PageInstance BuildPage(Template template, RenderingInstructions renderingInstructions)
        {
            template.ApplyAmendments(this.componentLibrary);

            var buildContext = new BuildContext { WidgetSpecificationFinder = n => this.widgetSpecificationRepository.Find(n) };

            var builder = new Builder(renderingInstructions);

            var page = template.Build(builder, buildContext);
            return page;
        }
    }
}