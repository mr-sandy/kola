namespace Kola.Domain.Composition
{
    using System.Collections.Generic;

    using Kola.Domain.Instances;
    using Kola.Domain.Instances.Config;

    public interface IComponent
    {
        void Accept(IComponentVisitor visitor);

        T Accept<T>(IComponentVisitor<T> visitor);

        T Accept<T, TContext>(IComponentVisitor<T, TContext> visitor, TContext context);

        ComponentInstance Build(IBuilder builder, IEnumerable<int> path, IBuildSettings buildSettings);

        IComponent Clone();
    }
}