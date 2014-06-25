namespace Kola.Persistence.Extensions
{
    using System.Collections.Generic;
    using System.Linq;

    using Kola.Domain.Composition;
    using Kola.Domain.Composition.ParameterValues;
    using Kola.Persistence.SurrogateBuilders;
    using Kola.Persistence.Surrogates;

    public static class ParameterExtensions
    {
        public static Parameter ToDomain(this ParameterSurrogate surrogate)
        {
            var value = surrogate.Value.Accept(new ParameterValueBuildingVisitor());

            return new Parameter(surrogate.Name, surrogate.Type, value);
        }

        public static IEnumerable<Parameter> ToDomain(this IEnumerable<ParameterSurrogate> surrogates)
        {
            return surrogates == null
                ? null
                : surrogates.Select(ToDomain);
        }

        public static ParameterSurrogate ToSurrogate(this Parameter parameter)
        {
            return new ParameterSurrogate
                {
                    Name = parameter.Name,
                    Type = parameter.Type,
                    Value = parameter.Value == null ? null : parameter.Value.Accept(new SurrogateBuildingParameterValueVisitor())
                };
        }

        public static IEnumerable<ParameterSurrogate> ToSurrogate(this IEnumerable<Parameter> parameters)
        {
            return parameters == null
                ? null
                : parameters.Select(ToSurrogate);
        }
    }
}