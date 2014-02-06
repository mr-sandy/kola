namespace Kola.Domain.Templates
{
    using System.Linq;

    using Kola.Domain.Instances;
    using Kola.Domain.Instances.Building;

    public class PlaceholderTemplate : IComponentTemplate
    {
        public void Accept(IComponentTemplateVisitor visitor)
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