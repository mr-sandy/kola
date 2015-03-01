namespace Kola.Domain.Rendering
{
    using System.Collections.Generic;

    using Kola.Domain.Composition;
    using Kola.Domain.Instances;
    using Kola.Domain.Instances.Context;
    using Kola.Persistence;

    // TODO {SC} Move this class to the Kola.Service namespace? (it references Kola.Persistence, which doesn't seem very domainish)
    public class PageHandler : IPageHandler
    {
        private readonly ITemplateRepository templateRepository;

        private readonly IWidgetSpecificationRepository widgetSpecificationRepository;

        private readonly IComponentSpecificationLibrary componentLibrary;

        public PageHandler(ITemplateRepository templateRepository, IWidgetSpecificationRepository widgetSpecificationRepository, IComponentSpecificationLibrary componentLibrary)
        {
            this.templateRepository = templateRepository;
            this.widgetSpecificationRepository = widgetSpecificationRepository;
            this.componentLibrary = componentLibrary;
        }

        public PageInstance GetPage(IEnumerable<string> path, bool preview)
        {
            var template = this.templateRepository.Get(path);

            if (template == null)
            {
                return null;
            }

            template.ApplyAmendments(this.componentLibrary);

            var buildContext = new BuildContext
                {
                    WidgetSpecificationFinder = n => this.widgetSpecificationRepository.Find(n)
                };

            var renderingInstructions = preview
                ? new RenderingInstructions(false, true)
                : new RenderingInstructions(true, false);

            var builder = new Builder(renderingInstructions);

            return template.Build(builder, buildContext);
        }
    }
}