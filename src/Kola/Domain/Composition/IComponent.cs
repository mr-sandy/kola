namespace Kola.Domain.Composition
{
    using Kola.Domain.Instances;
    using Kola.Domain.Instances.Building;

    public interface IComponent
    {
        T Accept<T>(IComponentVisitor<T> visitor);

        T Accept<T, TContext>(IComponentVisitor<T, TContext> visitor, TContext context);

        IComponentInstance Build(IBuildContext buildContext);
    }
}