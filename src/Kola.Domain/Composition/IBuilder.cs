namespace Kola.Domain.Composition
{
    using System.Collections.Generic;

    using Kola.Domain.Instances;
    using Kola.Domain.Instances.Context;

    public interface IBuilder
    {
        PageInstance Build(Template template, IBuildContext buildContext);

        AtomInstance Build(Atom atom, IEnumerable<int> path, IBuildContext buildContext);

        ContainerInstance Build(Container container, IEnumerable<int> path, IBuildContext buildContext);

        WidgetInstance Build(Widget widget, IEnumerable<int> path, IBuildContext buildContext);

        PlaceholderInstance Build(Placeholder placeholder, IEnumerable<int> path, IBuildContext buildContext);

        AreaInstance Build(Area area, IEnumerable<int> path, IBuildContext buildContext);
    }
}