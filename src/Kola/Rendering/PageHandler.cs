namespace Kola.Rendering
{
    using System.Collections.Generic;

    using Kola.Domain;
    using Kola.Persistence;
    using Kola.Rendering.Extensions;

    public class PageHandler : IPageHandler
    {
        private readonly ITemplateRepository templateRepository;

        private readonly IComponentLibrary componentLibrary;

        public PageHandler(ITemplateRepository templateRepository, IComponentLibrary componentLibrary)
        {
            this.templateRepository = templateRepository;
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
            return template.ToPage();
        }
    }
}