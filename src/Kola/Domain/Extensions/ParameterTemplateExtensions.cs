namespace Kola.Domain.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Kola.Domain.Templates;

    public static class ParameterTemplateExtensions
    {
        public static ParameterTemplate Find(this IEnumerable<ParameterTemplate> parameters, string parameterName)
        {
            return parameters.Where(p => p.Name.Equals(parameterName, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
        }
    }
}