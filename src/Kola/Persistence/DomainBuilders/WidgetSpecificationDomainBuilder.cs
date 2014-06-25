namespace Kola.Persistence.DomainBuilders
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
                surrogate.Components.Select(c => c.Accept(componentBuilder)));
        }
    }
}