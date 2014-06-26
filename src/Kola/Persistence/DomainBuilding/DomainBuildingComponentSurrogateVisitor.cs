namespace Kola.Persistence.DomainBuilding
{
    using System.Collections.Generic;
    using System.Linq;

    using Kola.Domain.Composition;
    using Kola.Persistence.Surrogates;

    internal class DomainBuildingComponentSurrogateVisitor : IComponentSurrogateVisitor<IComponent>
    {
        private readonly DomainBuildingParameterValueVisitor parameterValueBuilder = new DomainBuildingParameterValueVisitor();

        public IComponent Visit(ContainerSurrogate surrogate)
        {
            return new Container(
                surrogate.Name,
                this.BuildParameters(surrogate.Parameters),
                surrogate.Components.Select(c => c.Accept(this)));
        }

        public IComponent Visit(AtomSurrogate surrogate)
        {
            return new Atom(
                surrogate.Name,
                this.BuildParameters(surrogate.Parameters));
        }

        public IComponent Visit(WidgetSurrogate surrogate)
        {
            var areas = surrogate.Areas == null 
                ? Enumerable.Empty<Area>() 
                : surrogate.Areas.Select(area =>
                    {
                        var components = area.Components == null 
                            ? Enumerable.Empty<IComponent>()
                            : area.Components.Select(c => c.Accept(this));

                        return new Area(components);
                    });

            return new Widget(
                surrogate.Name,
                areas,
                this.BuildParameters(surrogate.Parameters));
        }

        public IComponent Visit(PlaceholderSurrogate surrogate)
        {
            return new Placeholder();
        }

        private IEnumerable<Parameter> BuildParameters(IEnumerable<ParameterSurrogate> surrogates)
        {
            if (surrogates == null)
            {
                return Enumerable.Empty<Parameter>();
            }

            return surrogates.Select(surrogate => new Parameter(
                surrogate.Name, 
                surrogate.Type, 
                surrogate.Value.Accept(this.parameterValueBuilder)));
        }
    }
}