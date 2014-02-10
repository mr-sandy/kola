namespace Kola.Domain.Specifications
{
    using System.Collections.Generic;

    using Kola.Domain.Templates;

    public interface INamedComponentSpecification<out T> 
        where T : INamedComponentTemplate
    {
        string Name { get; }

        IEnumerable<ParameterSpecification> Parameters { get; }

        void AddParameter(ParameterSpecification parameter);

        T Create();
    }
}