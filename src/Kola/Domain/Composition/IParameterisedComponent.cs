namespace Kola.Domain.Composition
{
    using System.Collections.Generic;

    using Kola.Domain.Composition.ParameterValues;
    using Kola.Domain.Specifications;

    public interface IParameterisedComponent : IComponent
    {
        string Name { get; }

        IEnumerable<Parameter> Parameters { get; }

        void SetParameter(string parameterName, IParameterValue parameterValue, IParameterisedComponentSpecification<IParameterisedComponent> specification);
    }
}