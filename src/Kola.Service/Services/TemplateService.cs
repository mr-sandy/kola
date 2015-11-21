namespace Kola.Service.Services
{
    using System.Collections.Generic;

    using Kola.Domain.Composition;
    using Kola.Domain.Composition.Amendments;
    using Kola.Domain.Extensions;
    using Kola.Persistence;
    using Kola.Persistence.Extensions;
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
            var existingTemplate = this.contentRepository.GetTemplate(path);

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
            var template = this.contentRepository.GetTemplate(path);

            if (template == null)
            {
                return new NotFoundResult<Template>();
            }

            template.ApplyAmendments(this.componentLibrary);

            new ComponentRefreshingVisitor(this.componentLibrary).Refresh(template);

            return new SuccessResult<Template>(template);
        }

        public IResult<ComponentDetails> GetComponent(IEnumerable<string> templatePath, IEnumerable<int> componentPath)
        {
            var template = this.contentRepository.GetTemplate(templatePath);

            if (template == null)
            {
                return new NotFoundResult<ComponentDetails>();
            }

            template.ApplyAmendments(this.componentLibrary);

            var component = template.FindComponent(componentPath);

            // Add all properties for this component type (not just those with values set)
            component.Accept(new ComponentRefreshingVisitor(this.componentLibrary));

            return new SuccessResult<ComponentDetails>(new ComponentDetails(template, component, componentPath));
        }

        public IResult<AmendmentDetails> AddAmendment(IEnumerable<string> path, IAmendment amendment)
        {
            var template = this.contentRepository.GetTemplate(path);

            if (template == null)
            {
                return new NotFoundResult<AmendmentDetails>();
            }

            template.AddAmendment(amendment);

            this.contentRepository.Update(template);

            template.ApplyAmendments(this.componentLibrary);

            return new CreatedResult<AmendmentDetails>(new AmendmentDetails(template, amendment));
        }

        public IResult<AmendmentsDetails> GetAmendments(IEnumerable<string> path)
        {
            var template = this.contentRepository.GetTemplate(path);

            if (template == null)
            {
                return new NotFoundResult<AmendmentsDetails>();
            }

            return new SuccessResult<AmendmentsDetails>(new AmendmentsDetails(template));
        }

        public IResult<AmendmentsDetails> ApplyAmendments(IEnumerable<string> path)
        {
            var template = this.contentRepository.GetTemplate(path);

            if (template == null)
            {
                return new NotFoundResult<AmendmentsDetails>();
            }

            template.ApplyAmendments(this.componentLibrary, reset: true);

            this.contentRepository.Update(template);

            return new SuccessResult<AmendmentsDetails>(new AmendmentsDetails(template));
        }

        public IResult<UndoAmendmentDetails> UndoAmendment(IEnumerable<string> path)
        {
            var template = this.contentRepository.GetTemplate(path);

            if (template == null)
            {
                return new NotFoundResult<UndoAmendmentDetails>();
            }

            var amendment = template.UndoAmendment();

            this.contentRepository.Update(template);

            return new SuccessResult<UndoAmendmentDetails>(new UndoAmendmentDetails(template, amendment));
        }
    }
}