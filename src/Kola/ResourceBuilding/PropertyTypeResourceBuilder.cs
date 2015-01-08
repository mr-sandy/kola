namespace Kola.ResourceBuilding
{
    using System.Collections.Generic;
    using System.Linq;

    using Kola.Configuration;
    using Kola.Extensions;
    using Kola.Resources;

    internal class PropertyTypeResourceBuilder
    {
        public PropertyTypeResource Build(PropertyTypeSpecification propertiespecification)
        {
            return new PropertyTypeResource
            {
                Name = propertiespecification.Name,
                DefaultValue = propertiespecification.DefaultValue,
                Links = new[]
                        {
                            new LinkResource { Rel = "self", Href = "/_kola/property-types/" + propertiespecification.Name.Urlify() },
                            new LinkResource { Rel = "editor", Href = "/_kola/editors/" + propertiespecification.EditorName }
                        }
            };
        }

        public IEnumerable<PropertyTypeResource> Build(IEnumerable<PropertyTypeSpecification> propertySpecifications)
        {
            return propertySpecifications.Select(this.Build);
        }
    }
}