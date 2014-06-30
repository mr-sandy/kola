namespace Kola.Domain.Composition
{
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

        public IComponentInstance Build(IBuildContext buildContext)
        {
            return new PlaceholderInstance(buildContext.AreaContents.Peek().Dequeue());
        }
    }
}