namespace Kola.Service.ResourceBuilding
{
    using Kola.Domain.Specifications;

    internal class ComponentNamingSpecificationVisitor : IComponentSpecificationVisitor<string>
    {
        public string Visit(AtomSpecification atomSpecification)
        {
            return "atom";
        }

        public string Visit(ContainerSpecification containerSpecification)
        {
            return "container";
        }

        public string Visit(WidgetSpecification widgetSpecification)
        {
            return "widget";
        }
    }
}