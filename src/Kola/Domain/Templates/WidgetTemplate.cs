namespace Kola.Domain.Templates
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Kola.Domain.Instances;

    public class WidgetTemplate : IParameterisedComponent
    {
        public WidgetTemplate(string name, IEnumerable<ParameterTemplate> parameters, IEnumerable<Area> areas)
        {
            this.Name = name;
            this.Parameters = parameters;
            this.Areas = areas;
        }

        public string Name { get; private set; }

        public IEnumerable<ParameterTemplate> Parameters { get; private set; }

        public IEnumerable<Area> Areas { get; private set; }

        public void Accept(IComponentTemplateVisitor visitor)
        {
            visitor.Visit(this);
        }

        public IComponentInstance Build(IBuildContext buildContext)
        {
            var specification = buildContext.WidgetSpecificationFinder(this.Name);

            buildContext.Areas.Push(new Queue<Area>(this.Areas));

            var children = specification.Components.Select(c => c.Build(buildContext)).ToList();

            buildContext.Areas.Pop();

            return new WidgetInstance(this.Name, children);
        }
    }
}