namespace Unit.Tests.Temp.Domain.Templates
{
    using System.Linq;

    using Unit.Tests.Temp.Domain.Instances;

    public class Placeholder : IComponent
    {
        public IInstance Build(IBuildContext buildContext)
        {
            var area = buildContext.Areas.Peek().Dequeue();

            var components = area.Children.Select(c => c.Build(buildContext));

            return new PlaceholderInstance(components);
        }
    }
}
