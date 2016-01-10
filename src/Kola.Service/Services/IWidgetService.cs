namespace Kola.Service.Services
{
    using System.Collections.Generic;

    using Kola.Domain.Composition.Amendments;
    using Kola.Domain.Specifications;
    using Kola.Service.Services.Models;
    using Kola.Service.Services.Results;

    public interface IWidgetService
    {
        IResult<WidgetSpecification> CreateWidget(string widgetName);

        IResult<WidgetSpecification> GetWidget(string widgetName);

        IResult<ComponentDetails> GetComponent(string widgetName, IEnumerable<int> componentPath);

        IResult<AmendmentDetails> AddAmendment(string widgetName, IAmendment amendment);

        IResult<AmendmentsDetails> GetAmendments(string widgetName);

        IResult<AmendmentsDetails> ApplyAmendments(string widgetName);

        IResult<UndoAmendmentDetails> UndoAmendment(string widgetName);
    }
}