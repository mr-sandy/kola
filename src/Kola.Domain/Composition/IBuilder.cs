namespace Kola.Domain.Composition
{
    using System.Collections.Generic;

    using Kola.Domain.Instances;
    using Kola.Domain.Instances.Context;

    public interface IBuilder
    {
        PageInstance Build(Template template, IBuildContext buildContext);

        ComponentInstance Build(Atom atom, IEnumerable<int> path, IBuildContext buildContext);

        ComponentInstance Build(Container container, IEnumerable<int> path, IBuildContext buildContext);

        ComponentInstance Build(Widget widget, IEnumerable<int> path, IBuildContext buildContext);

        ComponentInstance Build(Placeholder placeholder, IEnumerable<int> path, IBuildContext buildContext);

        ComponentInstance Build(Area area, IEnumerable<int> path, IBuildContext buildContext);

    }
}