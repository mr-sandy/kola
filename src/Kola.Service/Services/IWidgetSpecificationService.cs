namespace Kola.Service.Services
{
    using System.Collections.Generic;

    using Kola.Domain.Composition.Amendments;
    using Kola.Domain.Specifications;
    using Kola.Service.Services.Models;
    using Kola.Service.Services.Results;

    public interface IWidgetSpecificationService
    {
        IResult<WidgetSpecification> CreateWidgetSpecification(string widgetName);

        IResult<WidgetSpecification> GetWidgetSpecification(string widgetName);

        IResult<ComponentDetails> GetComponent(string widgetName, IEnumerable<int> componentPath);

        IResult<AmendmentDetails> AddAmendment(string widgetName, IAmendment amendment);

        IResult<AmendmentsDetails> GetAmendments(string widgetName);

        IResult<AmendmentsDetails> ApplyAmendments(string widgetName);

        IResult<UndoAmendmentDetails> UndoAmendment(string widgetName);
    }
}