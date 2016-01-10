namespace Kola.Service.Services
{
    using System.Collections.Generic;
    using System.Linq;

    using Kola.Domain.Composition;
    using Kola.Domain.Composition.Amendments;
    using Kola.Domain.Extensions;
    using Kola.Domain.Specifications;
    using Kola.Persistence;
    using Kola.Service.Services.Models;
    using Kola.Service.Services.Results;

    public class WidgetService : IWidgetService
    {
        private readonly IWidgetSpecificationRepository widgetSpecificationRepository;
        private readonly IComponentSpecificationLibrary componentLibrary;

        public WidgetService(IWidgetSpecificationRepository widgetSpecificationRepository, IComponentSpecificationLibrary componentLibrary)
        {
            this.widgetSpecificationRepository = widgetSpecificationRepository;
            this.componentLibrary = componentLibrary;
        }

        public IResult<WidgetSpecification> CreateWidget(string widgetName)
        {
            if (this.widgetSpecificationRepository.Find(widgetName) != null)
            {
                return new ConflictResult<WidgetSpecification>();
            }

            var widgetSpecification = new WidgetSpecification(widgetName);

            this.widgetSpecificationRepository.Save(widgetSpecification);

            return new CreatedResult<WidgetSpecification>(widgetSpecification);
        }

        public IResult<WidgetSpecification> GetWidget(string widgetName)
        {
            var widgetSpecification = this.widgetSpecificationRepository.Find(widgetName);

            if (widgetSpecification == null)
            {
                return new NotFoundResult<WidgetSpecification>();
            }

            widgetSpecification.ApplyAmendments(this.componentLibrary);

            new ComponentRefreshingVisitor(this.componentLibrary).Refresh(widgetSpecification);

            return new SuccessResult<WidgetSpecification>(widgetSpecification);

        }

        public IResult<ComponentDetails> GetComponent(string widgetName, IEnumerable<int> rawComponentPath)
        {
            var widgetSpecification = this.widgetSpecificationRepository.Find(widgetName);

            if (widgetSpecification == null)
            {
                return new NotFoundResult<ComponentDetails>();
            }

            widgetSpecification.ApplyAmendments(this.componentLibrary);

            var componentPath = rawComponentPath as int[] ?? rawComponentPath.ToArray();

            var component = widgetSpecification.FindComponent(componentPath);

            // Add all properties for this component type (not just those with values set)
            component.Accept(new ComponentRefreshingVisitor(this.componentLibrary));

            return new SuccessResult<ComponentDetails>(new ComponentDetails(widgetSpecification, component, componentPath));
        }

        public IResult<AmendmentDetails> AddAmendment(string widgetName, IAmendment amendment)
        {
            var widgetSpecification = this.widgetSpecificationRepository.Find(widgetName);

            if (widgetSpecification == null)
            {
                return new NotFoundResult<AmendmentDetails>();
            }

            widgetSpecification.AddAmendment(amendment);

            this.widgetSpecificationRepository.Save(widgetSpecification);

            widgetSpecification.ApplyAmendments(this.componentLibrary);

            return new CreatedResult<AmendmentDetails>(new AmendmentDetails(widgetSpecification, amendment));
        }

        public IResult<AmendmentsDetails> GetAmendments(string widgetName)
        {
            var widgetSpecification = this.widgetSpecificationRepository.Find(widgetName);

            if (widgetSpecification == null)
            {
                return new NotFoundResult<AmendmentsDetails>();
            }

            return new SuccessResult<AmendmentsDetails>(new AmendmentsDetails(widgetSpecification));
        }

        public IResult<AmendmentsDetails> ApplyAmendments(string widgetName)
        {
            var widgetSpecification = this.widgetSpecificationRepository.Find(widgetName);

            if (widgetSpecification == null)
            {
                return new NotFoundResult<AmendmentsDetails>();
            }

            widgetSpecification.ApplyAmendments(this.componentLibrary, reset: true);

            this.widgetSpecificationRepository.Save(widgetSpecification);

            return new SuccessResult<AmendmentsDetails>(new AmendmentsDetails(widgetSpecification));
        }

        public IResult<UndoAmendmentDetails> UndoAmendment(string widgetName)
        {
            var widgetSpecification = this.widgetSpecificationRepository.Find(widgetName);

            if (widgetSpecification == null)
            {
                return new NotFoundResult<UndoAmendmentDetails>();
            }

            var amendment = widgetSpecification.UndoAmendment();

            this.widgetSpecificationRepository.Save(widgetSpecification);

            return new SuccessResult<UndoAmendmentDetails>(new UndoAmendmentDetails(widgetSpecification, amendment));
        }
    }
}