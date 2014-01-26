namespace Kola.Domain.Templates
{
    using Kola.Domain.Instances;
 
    public interface IComponent
    {
        void Accept(IComponentVisitor visitor);

        IComponentInstance Build(BuildContext buildContext);
    }
}