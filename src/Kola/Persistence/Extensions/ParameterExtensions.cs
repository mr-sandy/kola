namespace Kola.Persistence.Extensions
{
    using System.Collections.Generic;
    using System.Linq;

    using Kola.Domain.Templates;
    using Kola.Domain.Templates.ParameterValues;
    using Kola.Persistence.Surrogates;

    public static class ParameterExtensions
    {
        public static Parameter ToDomain(this ParameterSurrogate surrogate)
        {
            var value = surrogate.Value == null
                ? new UndefinedParameterValue()
                : surrogate.Value.Accept(new ParameterValueBuildingVisitor());

            return new Parameter(surrogate.Name, surrogate.Type)
                {
                    Value = value
                };
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
                    Value = parameter.Value == null ? null : parameter.Value.Accept(new ParameterValueSurrogateBuildingVisitor())
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