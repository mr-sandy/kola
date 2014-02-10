namespace Kola.Domain.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Kola.Domain.Specifications;

    public static class ParameterSpecificationExtensions
    {
        public static ParameterSpecification Find(this IEnumerable<ParameterSpecification> parameters, string parameterName)
        {
            return parameters.Where(p => p.Name.Equals(parameterName, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
        }
    }
}