namespace Kola.Rendering
{
    using System;
    using System.Collections.Generic;

    using Kola.Editing;
    using Kola.Persistence;

    public class PageHandler : IPageHandler
    {
        private readonly ITemplateRepository templateRepository;

        public PageHandler(ITemplateRepository templateRepository)
        {
            this.templateRepository = templateRepository;
        }

        public IPage GetPage(IEnumerable<string> path)
        {
            var template = this.templateRepository.Get(path);

            if (template == null)
            {
                return null;
            }

            return this.MakePage(template);
        }

        private IPage MakePage(Template template)
        {
            throw new NotImplementedException();
        }
    }
}