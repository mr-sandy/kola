namespace Kola.Domain.Specifications
{
    using System.Collections.Generic;

    using Kola.Domain.Composition;

    public interface IComponentSpecification<out T> 
        where T : IParameterisedComponent
    {
        string Name { get; }

        IEnumerable<ParameterSpecification> Parameters { get; }

        void AddParameter(ParameterSpecification parameter);

        TV Accept<TV>(IComponentSpecificationVisitor<TV> visitor);

        T Create();
    }
}