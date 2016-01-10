namespace Kola.Persistence.DomainBuilding
{
    using System.Linq;

    using Kola.Domain.Specifications;
    using Kola.Persistence.Surrogates;
    using Kola.Persistence.Surrogates.Amendments;

    internal class WidgetSpecificationDomainBuilder
    {
        private readonly string name;

        public WidgetSpecificationDomainBuilder(string name)
        {
            this.name = name;
        }

        public WidgetSpecification Build(WidgetSpecificationSurrogate surrogate)
        {
            var componentBuilder = new DomainBuildingComponentSurrogateVisitor();
            var amendmentBuilder = new DomainBuildingAmendmentSurrogateVisitor();

            return new WidgetSpecification(
                this.name,
                surrogate.PropertySpecifications.Select(this.BuildPropertySpecification).ToArray(),
                surrogate.Components.Select(c => c.Accept(componentBuilder)).ToArray(),
                (surrogate.Amendments ?? Enumerable.Empty<AmendmentSurrogate>()).Select(a => a.Accept(amendmentBuilder)).ToArray(),
                surrogate.Category);
        }

        private PropertySpecification BuildPropertySpecification(PropertySpecificationSurrogate surrogate)
        {
            return new PropertySpecification(surrogate.Name, surrogate.Type, surrogate.DefaultValue);
        }
    }
}