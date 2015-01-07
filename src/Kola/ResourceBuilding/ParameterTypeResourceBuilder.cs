namespace Kola.ResourceBuilding
{
    using System.Collections.Generic;
    using System.Linq;

    using Kola.Configuration;
    using Kola.Extensions;
    using Kola.Resources;

    internal class ParameterTypeResourceBuilder
    {
        public ParameterTypeResource Build(ParameterTypeSpecification parameterSpecification)
        {
            return new ParameterTypeResource
            {
                Name = parameterSpecification.Name,
                DefaultValue = parameterSpecification.DefaultValue,
                Links = new[]
                        {
                            new LinkResource { Rel = "self", Href = "/_kola/parameter-types/" + parameterSpecification.Name.Urlify() },
                            new LinkResource { Rel = "editor", Href = "/_kola/editors/" + parameterSpecification.EditorName }
                        }
            };
        }

        public IEnumerable<ParameterTypeResource> Build(IEnumerable<ParameterTypeSpecification> parameterSpecifications)
        {
            return parameterSpecifications.Select(this.Build);
        }
    }
}