namespace Kola.Domain.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Kola.Domain.Composition;

    public static class ParameterExtensions
    {
        public static Parameter Find(this IEnumerable<Parameter> parameters, string parameterName)
        {
            return parameters.Where(p => p.Name.Equals(parameterName, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
        }
    }
}