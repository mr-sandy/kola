namespace Kola.Rendering
{
    using System.Collections.Generic;

    using Kola.Domain;
    using Kola.Domain.Instances;
    using Kola.Domain.Templates;
    using Kola.Persistence;
    using Kola.Rendering.Extensions;

    public class PageHandler : IPageHandler
    {
        private readonly ITemplateRepository templateRepository;

        private readonly IWidgetSpecificationRepository widgetSpecificationRepository;

        private readonly IComponentLibrary componentLibrary;

        public PageHandler(ITemplateRepository templateRepository, IWidgetSpecificationRepository widgetSpecificationRepository, IComponentLibrary componentLibrary)
        {
            this.templateRepository = templateRepository;
            this.widgetSpecificationRepository = widgetSpecificationRepository;
            this.componentLibrary = componentLibrary;
        }

        public IPage GetPage(IEnumerable<string> path)
        {
            var template = this.templateRepository.Get(path);

            if (template == null)
            {
                return null;
            }

            template.ApplyAmendments(this.componentLibrary);

            return template.ToPage(this.widgetSpecificationRepository);
        }
    }
}