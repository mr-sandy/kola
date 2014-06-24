namespace Kola.Domain.Composition
{
    using Kola.Domain.Instances;
    using Kola.Domain.Instances.Building;
    using Kola.Extensions;

    public interface IComponent
    {
        void Accept(IComponentVisitor visitor);

        //TResult Accept<TResult, TContext>(IComponentVisitor2<TResult, TContext> visitor, TContext context);

        IComponentInstance Build(IBuildContext buildContext);
    }
}