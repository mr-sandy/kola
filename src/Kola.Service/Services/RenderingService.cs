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

        public IResult<PageInstance> GetPage(IEnumerable<string> path, bool preview)
        {
            var template = this.templateRepository.Get(path);

            if (template == null)
            {
                return new NotFoundResult<PageInstance>();
            }

            template.ApplyAmendments(this.componentLibrary);

            var buildContext = new BuildContext
            {
                WidgetSpecificationFinder = n => this.widgetSpecificationRepository.Find(n)
            };

            var renderingInstructions = new RenderingInstructions(useCache: !preview, annotateComponentPaths: preview);

            var builder = new Builder(renderingInstructions);

            return new SuccessResult<PageInstance>(template.Build(builder, buildContext));
        }

        public IResult<PageInstance> GetFragment(IEnumerable<string> path, IEnumerable<int> componentPath)
        {
            throw new System.NotImplementedException();
        }
    }
}