namespace Kola.Domain.Composition
{
    using System.Collections.Generic;

    using Kola.Configuration;

    public interface IParameterSpecificationLibrary
    {
        IEnumerable<ParameterTypeSpecification> FindAll();

        ParameterTypeSpecification Find(string name);
    }
}