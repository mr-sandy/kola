namespace Kola.Domain.Composition
{
    using System.Linq;

    using Kola.Domain.Instances;
    using Kola.Domain.Instances.Building;

    public class Placeholder : IComponent
    {
        public void Accept(IComponentVisitor visitor)
        {
            visitor.Visit(this);
        }

        public IComponentInstance Build(IBuildContext buildContext)
        {
            var components = buildContext.Areas.Peek().Count() == 0
                ? Enumerable.Empty<IComponentInstance>()
                : buildContext.Areas.Peek().Dequeue();

            return new PlaceholderInstance(components);
        }
    }
}