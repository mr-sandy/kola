namespace Kola.Extensions
{
    using System.Collections.Generic;
    using System.Linq;

    using Kola.Domain.Templates;
    using Kola.Resources;

    internal static class ParameterExtensions
    {
        public static ParameterResource ToResource(this ParameterTemplate parameter)
        {
            if (parameter == null)
            {
                return null;
            }

            return new ParameterResource
                {
                    Name = parameter.Name,
                    Type = parameter.Type
                };
        }

        public static IEnumerable<ParameterResource> ToResource(this IEnumerable<ParameterTemplate> parameters)
        {
            return parameters == null 
                ? null 
                : parameters.Select(ToResource);
        }
    }
}