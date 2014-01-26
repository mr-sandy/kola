namespace Kola.Domain.Templates
{
    using System.Collections.Generic;

    using Kola.Domain.Instances;
 
    public interface IComponent
    {
        void Accept(IComponentVisitor visitor);

        IComponentInstance Build(BuildContext buildContext);
    }

    public interface IParameterisedComponent : IComponent
    {
        string Name { get; }

        IEnumerable<Parameter> Parameters { get; }
    }
}