namespace Kola.Persistence.DomainBuilding
{
    using System;
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
                this.BuildParameters(surrogate.Parameters).ToArray(),
                surrogate.Components.Select(c => c.Accept(this)).ToArray());
        }

        public IComponent Visit(AtomSurrogate surrogate)
        {
            return new Atom(
                surrogate.Name,
                this.BuildParameters(surrogate.Parameters).ToArray());
        }

        public IComponent Visit(WidgetSurrogate surrogate)
        {
            // TODO Here is a cast!!
            return new Widget(
                surrogate.Name,
                surrogate.Areas.Select(a => a.Accept(this)).Cast<Area>().ToArray(),
                this.BuildParameters(surrogate.Parameters).ToArray());
        }

        public IComponent Visit(PlaceholderSurrogate surrogate)
        {
            return new Placeholder();
        }

        public IComponent Visit(AreaSurrogate surrogate)
        {
            return new Area(surrogate.Components.Select(c => c.Accept(this)).ToArray());
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
                surrogate.Value.Accept(this.parameterValueBuilder))).ToArray();
        }
    }
}