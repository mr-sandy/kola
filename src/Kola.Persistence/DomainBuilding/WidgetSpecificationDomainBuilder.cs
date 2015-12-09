namespace Kola.Persistence.DomainBuilding
{
    using System.Linq;

    using Kola.Domain.Specifications;
    using Kola.Persistence.Surrogates;

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

            return new WidgetSpecification(
                this.name,
                surrogate.PropertySpecifications.Select(this.BuildPropertySpecification).ToArray(),
                surrogate.Components.Select(c => c.Accept(componentBuilder)).ToArray(),
                surrogate.Category);
        }

        private PropertySpecification BuildPropertySpecification(PropertySpecificationSurrogate surrogate)
        {
            return new PropertySpecification(surrogate.Name, surrogate.Type, surrogate.DefaultValue);
        }
    }
}