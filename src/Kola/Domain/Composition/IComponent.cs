namespace Kola.Domain.Composition
{
    using System.Collections.Generic;

    using Kola.Domain.Instances;
    using Kola.Domain.Instances.Building;

    public interface IComponent
    {
        void Accept(IComponentVisitor visitor);

        T Accept<T>(IComponentVisitor<T> visitor);

        T Accept<T, TContext>(IComponentVisitor<T, TContext> visitor, TContext context);

        // TODO Refactor this as visitor?
        ComponentInstance Build(IEnumerable<int> path, IBuildContext buildContext);

        IComponent Clone();
    }
}