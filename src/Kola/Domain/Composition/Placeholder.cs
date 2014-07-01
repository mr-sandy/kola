namespace Kola.Domain.Composition
{
    using System.Collections.Generic;

    using Kola.Domain.Instances;
    using Kola.Domain.Instances.Building;

    public class Placeholder : IComponent
    {
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
            return new PlaceholderInstance(path, buildContext.AreaContents.Peek().Dequeue());
        }
    }
}