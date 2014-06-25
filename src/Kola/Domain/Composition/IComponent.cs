namespace Kola.Domain.Composition
{
    using Kola.Domain.Instances;
    using Kola.Domain.Instances.Building;

    public interface IComponent
    {
        void Accept(IComponentVisitor visitor);

        T Accept<T, TContext>(IComponentVisitor<T, TContext> visitor, TContext context);

        IComponentInstance Build(IBuildContext buildContext);
    }
}