namespace Kola.Domain.Composition
{
    using System.Collections.Generic;

    using Kola.Domain.Specifications;

    public interface IParameterisedComponent : IComponent
    {
        string Name { get; }

        IEnumerable<Parameter> Parameters { get; }

        Parameter AddParameter(string parameterName, IParameterisedComponentSpecification<IParameterisedComponent> specification);
    }
}