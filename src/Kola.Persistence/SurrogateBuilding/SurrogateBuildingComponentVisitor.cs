namespace Kola.Persistence.SurrogateBuilding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Kola.Domain.Composition;
    using Kola.Persistence.Surrogates;

    internal class SurrogateBuildingComponentVisitor : IComponentVisitor<ComponentSurrogate>
    {
        private readonly SurrogateBuildingPropertyValueVisitor propertyValueBuilder = new SurrogateBuildingPropertyValueVisitor();
        
        public ComponentSurrogate Visit(Atom atom)
        {
            return new AtomSurrogate
            {
                Name = atom.Name,
                Properties = this.BuildProperties(atom.Properties).ToArray(),
                Comment = atom.Comment
            };
        }

        public ComponentSurrogate Visit(Container container)
        {
            return new ContainerSurrogate
            {
                Name = container.Name,
                Components = container.Components.Select(c => c.Accept(this)).ToArray(),
                Properties = this.BuildProperties(container.Properties).ToArray(),
                Comment = container.Comment
            };
        }

        public ComponentSurrogate Visit(Widget widget)
        {
            return new WidgetSurrogate
            {
                Name = widget.Name,
                Areas = widget.Areas.Select(a => a.Accept(this)).ToArray(),
                Properties = this.BuildProperties(widget.Properties).ToArray(),
                Comment = widget.Comment
            };
        }

        public ComponentSurrogate Visit(Placeholder placeholder)
        {
            return new PlaceholderSurrogate();
        }

        public ComponentSurrogate Visit(Area area)
        {
            return new AreaSurrogate { Name = area.Name, Components = area.Components.Select(c => c.Accept(this)).ToArray() };
        }

        private IEnumerable<PropertySurrogate> BuildProperties(IEnumerable<Property> properties)
        {
            return properties.Select(property => new PropertySurrogate
                {
                    Name = property.Name,
                    Type = property.Type,
                    Value = property.Value == null ? null : property.Value.Accept(this.propertyValueBuilder)
                });
        }
    }
}