namespace Kola.Domain.Composition
{
    using System.Collections.Generic;

    using Kola.Domain.Instances;
    using Kola.Domain.Instances.Config;

    public interface IBuilder
    {
        PageInstance Build(Template template, IBuildSettings buildSettings);

        AtomInstance Build(Atom atom, IEnumerable<int> path, IBuildSettings buildSettings);

        ContainerInstance Build(Container container, IEnumerable<int> path, IBuildSettings buildSettings);

        WidgetInstance Build(Widget widget, IEnumerable<int> path, IBuildSettings buildSettings);

        PlaceholderInstance Build(Placeholder placeholder, IEnumerable<int> path, IBuildSettings buildSettings);

        AreaInstance Build(Area area, IEnumerable<int> path, IBuildSettings buildSettings);
    }
}