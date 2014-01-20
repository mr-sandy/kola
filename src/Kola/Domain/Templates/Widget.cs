namespace Kola.Domain.Templates
{
    using System.Linq;

    using Kola.Domain.Instances;

    public class Widget : IComponent
    {
        public Widget(string name)
        {
            this.Name = name;
        }

        public string Name { get; private set; }

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