namespace Unit.Tests.Temp.Domain.Templates
{
    using System.Linq;

    using Unit.Tests.Temp.Domain.Instances;

    public class PlaceholderTemplate : IComponentTemplate
    {
        public IComponentInstance Build(IBuildContext buildContext)
        {
            var area = buildContext.Areas.Peek().Dequeue();

            var components = area.Components.Select(c => c.Build(buildContext));

            return new PlaceholderInstance(components);
        }
    }
}
