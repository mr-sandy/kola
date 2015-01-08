namespace Kola.Service
{
    using System.Collections.Generic;
    using System.Linq;

    using Kola.Configuration;
    using Kola.Domain.Composition;

    public class PropertySpecificationLibrary : IPropertySpecificationLibrary
    {
        private readonly IKolaConfigurationRegistry registry;

        public PropertySpecificationLibrary(IKolaConfigurationRegistry registry)
        {
            this.registry = registry;
        }

        public IEnumerable<PropertyTypeSpecification> FindAll()
        {
            return this.registry.KolaConfiguration.Plugins.SelectMany(plugin => plugin.PropertyTypeSpecifications);
        }

        public PropertyTypeSpecification Find(string name)
        {
            return this.registry.KolaConfiguration.Plugins
                .SelectMany(plugin => plugin.PropertyTypeSpecifications)
                .FirstOrDefault(c => c.Name == name);

        }
    }
}