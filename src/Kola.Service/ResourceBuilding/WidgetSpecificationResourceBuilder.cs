namespace Kola.Service.ResourceBuilding
{
    using Kola.Domain.Specifications;

    public class WidgetSpecificationResourceBuilder : IResourceBuilder<WidgetSpecification>
    {
        public object Build(WidgetSpecification widgetSpecification)
        {
            return new ComponentTypeResourceBuilder().Build(widgetSpecification);
        }

        public string Location(WidgetSpecification widgetSpecification)
        {
            return $"/_kola/widgets/{widgetSpecification.Name}";
        }
    }
}