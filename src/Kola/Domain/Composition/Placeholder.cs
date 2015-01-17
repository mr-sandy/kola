namespace Kola.Domain.Composition
{
    using System.Collections.Generic;

    using Kola.Domain.Instances;
    using Kola.Domain.Instances.Building;

    public class Placeholder : IComponent
    {
        public Placeholder(string name)
        {
            this.Name = name;
        }

        public string Name { get; private set; }

        public void Accept(IComponentVisitor visitor)
        {
            visitor.Visit(this);
        }

        public T Accept<T>(IComponentVisitor<T> visitor)
        {
            return visitor.Visit(this);
        }

        public T Accept<T, TContext>(IComponentVisitor<T, TContext> visitor, TContext context)
        {
            return visitor.Visit(this, context);
        }

        public ComponentInstance Build(IEnumerable<int> path, IBuildContext buildContext)
        {
            var componentInstance = buildContext.AreaContents.Peek().ContainsKey(this.Name)
                                        ? buildContext.AreaContents.Peek()[this.Name]
                                        : null;

            return new PlaceholderInstance(path, componentInstance);
        }
    }
}