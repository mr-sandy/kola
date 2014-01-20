namespace Kola.Domain.Templates
{
    using System.Collections.Generic;

    using Kola.Domain.Instances;

    public interface IComponent
    {
        string Name { get; }

        IEnumerable<Parameter> Parameters { get; }

        void Accept(IComponentVisitor visitor);

        IComponentInstance Build(BuildContext buildContext);
    }
}