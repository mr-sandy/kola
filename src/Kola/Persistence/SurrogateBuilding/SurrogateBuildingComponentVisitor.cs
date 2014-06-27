namespace Kola.Persistence.SurrogateBuilding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Kola.Domain.Composition;
    using Kola.Persistence.Surrogates;

    internal class SurrogateBuildingComponentVisitor : IComponentVisitor<ComponentSurrogate>
    {
        private readonly SurrogateBuildingParameterValueVisitor parameterValueBuilder = new SurrogateBuildingParameterValueVisitor();
        
        public ComponentSurrogate Visit(Atom atom)
        {
            return new AtomSurrogate
            {
                Name = atom.Name,
                Parameters = this.BuildParameters(atom.Parameters).ToArray()
            };
        }

        public ComponentSurrogate Visit(Container container)
        {
            return new ContainerSurrogate
            {
                Name = container.Name,
                Components = container.Components.Select(c => c.Accept(this)).ToArray(),
                Parameters = this.BuildParameters(container.Parameters).ToArray()
            };
        }

        public ComponentSurrogate Visit(Widget widget)
        {
            return new WidgetSurrogate
            {
                Name = widget.Name,
                Areas = this.BuildAreas(widget.Areas).ToArray(),
                Parameters = this.BuildParameters(widget.Parameters).ToArray()
            };
        }

        public ComponentSurrogate Visit(Placeholder placeholder)
        {
            return new PlaceholderSurrogate();
        }

        private IEnumerable<ParameterSurrogate> BuildParameters(IEnumerable<Parameter> parameters)
        {
            return parameters.Select(parameter => new ParameterSurrogate
                {
                    Name = parameter.Name,
                    Type = parameter.Type,
                    Value = parameter.Value == null ? null : parameter.Value.Accept(this.parameterValueBuilder)
                });
        }

        private IEnumerable<AreaSurrogate> BuildAreas(IEnumerable<Area> areas)
        {
            return areas.Select(area => new AreaSurrogate
                {
                    Components = area.Components.Select(c => c.Accept(this)).ToArray()
                });
        }
    }
}