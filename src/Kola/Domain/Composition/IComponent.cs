namespace Kola.Domain.Composition
{
    using System.Collections.Generic;

    using Kola.Domain.Instances;
    using Kola.Domain.Instances.Context;

    public interface IComponent
    {
        void Accept(IComponentVisitor visitor);

        T Accept<T>(IComponentVisitor<T> visitor);

        T Accept<T, TContext>(IComponentVisitor<T, TContext> visitor, TContext context);

        ComponentInstance Build(IBuilder builder, IEnumerable<int> path, IBuildContext buildContext);

        IComponent Clone();
    }
}