namespace Kola.Service.Services
{
    using Kola.Domain.Specifications;
    using Kola.Service.Services.Results;

    public interface IWidgetService
    {
        IResult<WidgetSpecification> CreateWidget(string widgetName);
    }
}