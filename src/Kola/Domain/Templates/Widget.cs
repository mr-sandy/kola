namespace Kola.Domain.Templates
{
    using System.Collections.Generic;
    using System.Linq;

    using Kola.Domain.Instances;

    public class Widget : IComponent
    {
        public Widget(string name, IEnumerable<Parameter> parameters)
        {
            this.Name = name;
            this.Parameters = parameters;
        }

        public string Name { get; private set; }

        public IEnumerable<Parameter> Parameters { get; private set; }

        public void Accept(IComponentVisitor visitor)
        {
            visitor.Visit(this);
        }

        public IComponentInstance Build(BuildContext buildContext)
        {
            var specification = buildContext.WidgetSpecificationFinder(this.Name);

            var children = specification.Components.Select(c => c.Build(buildContext));

            return new WidgetInstance(this.Name, children);
        }
    }
}