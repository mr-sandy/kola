namespace Kola.Service.Services
{
    using System;
    using System.Collections.Generic;

    using Kola.Domain.Composition;
    using Kola.Domain.Composition.Amendments;
    using Kola.Domain.Extensions;
    using Kola.Persistence;
    using Kola.Service.Services.Models;
    using Kola.Service.Services.Results;

    public class TemplateService : ITemplateService
    {
        private readonly IContentRepository contentRepository;
        private readonly IComponentSpecificationLibrary componentLibrary;

        public TemplateService(IContentRepository contentRepository, IComponentSpecificationLibrary componentLibrary)
        {
            this.contentRepository = contentRepository;
            this.componentLibrary = componentLibrary;
        }

        public IResult<Template> CreateTemplate(IEnumerable<string> path)
        {
            var existingTemplate = this.contentRepository.Get(path) as Template;

            if (existingTemplate != null)
            {
                return new ConflictResult<Template>();
            }

            var template = new Template(path);

            this.contentRepository.Add(template);

            return new CreatedResult<Template>(template);
        }

        public IResult<Template> GetTemplate(IEnumerable<string> path)
        {
            var template = this.contentRepository.Get(path) as Template;

            if (template == null)
            {
                return new NotFoundResult<Template>();
            }

            template.ApplyAmendments(this.componentLibrary);

            new ComponentRefreshingVisitor(this.componentLibrary).Refresh(template);

            return new SuccessResult<Template>(template);
        }

        public IResult<TemplateAndComponent> GetComponent(IEnumerable<string> templatePath, IEnumerable<int> componentPath)
        {
            var template = this.contentRepository.Get(templatePath) as Template;

            if (template == null)
            {
                return new NotFoundResult<TemplateAndComponent>();
            }

            template.ApplyAmendments(this.componentLibrary);

            var component = template.FindComponent(componentPath);

            // Add all properties for this component type (not just those with values set)
            component.Accept(new ComponentRefreshingVisitor(this.componentLibrary));

            return new SuccessResult<TemplateAndComponent>(new TemplateAndComponent(template, component, componentPath));
        }

        public IResult<TemplateAndAmendment> AddAmendment(IEnumerable<string> path, IAmendment amendment)
        {
            var template = this.contentRepository.Get(path) as Template;

            if (template == null)
            {
                return new NotFoundResult<TemplateAndAmendment>();
            }

            template.AddAmendment(amendment);

            this.contentRepository.Update(template);

            template.ApplyAmendments(this.componentLibrary);

            return new CreatedResult<TemplateAndAmendment>(new TemplateAndAmendment(template, amendment));
        }

        public IResult<TemplateAndAmendments> GetAmendments(IEnumerable<string> path)
        {
            var template = this.contentRepository.Get(path) as Template;

            if (template == null)
            {
                return new NotFoundResult<TemplateAndAmendments>();
            }

            return new SuccessResult<TemplateAndAmendments>(new TemplateAndAmendments(template, template.Amendments));
        }

        public IResult<Template> ApplyAmendments(IEnumerable<string> path)
        {
            throw new System.NotImplementedException();
        }

        public IResult<IEnumerable<IEnumerable<int>>> UndoAmendment(IEnumerable<string> path)
        {
            throw new System.NotImplementedException();
        }
    }
}