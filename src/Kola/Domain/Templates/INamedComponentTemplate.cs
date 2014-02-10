namespace Kola.Domain.Templates
{
    using System.Collections.Generic;

    using Kola.Domain.Specifications;
    using Kola.Domain.Templates.ParameterValues;

    public interface INamedComponentTemplate : IComponentTemplate
    {
        string Name { get; }

        IEnumerable<ParameterTemplate> Parameters { get; }

        void SetParameter(string parameterName, IParameterValue parameterValue, INamedComponentSpecification<INamedComponentTemplate> specification);
    }
}