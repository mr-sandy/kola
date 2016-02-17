namespace Kola.Domain.Composition
{
    using System.Collections.Generic;

    using Kola.Domain.Instances;
    using Kola.Domain.Instances.Config;

    public interface IBuilder
    {
        PageInstance Build(Template template, IBuildData buildData);

        AtomInstance Build(Atom atom, IEnumerable<int> path, IBuildData buildData);

        ContainerInstance Build(Container container, IEnumerable<int> path, IBuildData buildData);

        WidgetInstance Build(Widget widget, IEnumerable<int> path, IBuildData buildData);

        PlaceholderInstance Build(Placeholder placeholder, IEnumerable<int> path, IBuildData buildData);

        AreaInstance Build(Area area, IEnumerable<int> path, IBuildData buildData);
    }
}