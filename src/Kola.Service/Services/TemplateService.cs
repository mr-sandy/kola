namespace Kola.Service.Services
{
    using System;
    using System.Collections.Generic;

    using Kola.Domain.Composition;
    using Kola.Domain.Composition.Amendments;
    using Kola.Persistence;
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

        public IResult<IComponent> GetComponent(IEnumerable<string> templatePath, IEnumerable<int> componentPath)
        {
            throw new System.NotImplementedException();
        }

        public IResult<Tuple<Template, IAmendment>> AddAmendment(IEnumerable<string> path, IAmendment amendment)
        {
            var template = this.contentRepository.Get(path) as Template;

            if (template == null)
            {
                return new NotFoundResult<Tuple<Template, IAmendment>>();
            }

            template.AddAmendment(amendment);

            this.contentRepository.Update(template);

            template.ApplyAmendments(this.componentLibrary);

            //            var resource = new AmendmentResourceBuilder().Build(amendment, template.Path, template.Amendments.Count() - 1);
            return new CreatedResult<Tuple<Template, IAmendment>>(new Tuple<Template, IAmendment>(template, amendment));
        }

        public IResult<IEnumerable<IAmendment>> GetAmendments(IEnumerable<string> path)
        {
            throw new System.NotImplementedException();
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