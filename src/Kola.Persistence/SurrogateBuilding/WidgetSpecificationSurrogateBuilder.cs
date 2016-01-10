namespace Kola.Persistence.SurrogateBuilding
{
    using System.Linq;

    using Kola.Domain.Specifications;
    using Kola.Persistence.Surrogates;

    internal class WidgetSpecificationSurrogateBuilder
    {
        public WidgetSpecificationSurrogate Build(WidgetSpecification widgetSpecification)
        {
            var componentBuilder = new SurrogateBuildingComponentVisitor();
            var amendmentBuilder = new SurrogateBuildingAmendmentVisitor();

            return new WidgetSpecificationSurrogate
                       {
                           Category = widgetSpecification.Category,
                           Components = widgetSpecification.Components.Select(c => c.Accept(componentBuilder)).ToArray(),
                           Amendments = widgetSpecification.Amendments.Select(a => a.Accept(amendmentBuilder)).ToArray(),
                           PropertySpecifications = widgetSpecification.Properties.Select(s =>
                                   new PropertySpecificationSurrogate
                                       {
                                           Name = s.Name,
                                           Type = s.Type,
                                           DefaultValue = s.DefaultValue
                                       }).ToArray()
                       };
        }
    }
}