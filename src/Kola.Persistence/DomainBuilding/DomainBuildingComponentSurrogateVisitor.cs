namespace Kola.Persistence.DomainBuilding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Kola.Domain.Composition;
    using Kola.Persistence.Surrogates;

    internal class DomainBuildingComponentSurrogateVisitor : IComponentSurrogateVisitor<IComponent>
    {
        private readonly DomainBuildingPropertyValueVisitor propertyValueBuilder = new DomainBuildingPropertyValueVisitor();

        public IComponent Visit(ContainerSurrogate surrogate)
        {
            return new Container(
                surrogate.Name,
                this.BuildProperties(surrogate.Properties).ToArray(),
                surrogate.Components.Select(c => c.Accept(this)).ToArray(),
                surrogate.Comment);
        }

        public IComponent Visit(AtomSurrogate surrogate)
        {
            return new Atom(
                surrogate.Name,
                this.BuildProperties(surrogate.Properties).ToArray(),
                surrogate.Comment);
        }

        public IComponent Visit(WidgetSurrogate surrogate)
        {
            return new Widget(
                surrogate.Name,
                surrogate.Areas.Select(a => a.Accept(this)).Cast<Area>().ToArray(),
                this.BuildProperties(surrogate.Properties).ToArray(),
                surrogate.Comment);
        }

        public IComponent Visit(PlaceholderSurrogate surrogate)
        {
            return new Placeholder(surrogate.Name);
        }

        public IComponent Visit(AreaSurrogate surrogate)
        {
            return new Area(surrogate.Name, surrogate.Components.Select(c => c.Accept(this)).ToArray());
        }

        private IEnumerable<Property> BuildProperties(IEnumerable<PropertySurrogate> surrogates)
        {
            if (surrogates == null)
            {
                return Enumerable.Empty<Property>();
            }

            return surrogates.Select(surrogate => new Property(
                surrogate.Name, 
                surrogate.Type, 
                surrogate.Value.Accept(this.propertyValueBuilder))).ToArray();
        }
    }
}