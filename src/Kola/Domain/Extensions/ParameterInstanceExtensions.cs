namespace Kola.Domain.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Kola.Domain.Instances;

    public static class ParameterInstanceExtensions
    {
        public static string Get(this IEnumerable<ParameterInstance> parameters, string parameterName, string fallback = "")
        {
            var parameter = parameters.Where(p => p.Name.Equals(parameterName, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();

            return parameter == null
                ? fallback
                : parameter.Value;
        }
    }
}