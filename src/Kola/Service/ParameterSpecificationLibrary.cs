namespace Kola.Service
{
    using System.Collections.Generic;
    using System.Linq;

    using Kola.Configuration;
    using Kola.Domain.Composition;

    public class ParameterSpecificationLibrary : IParameterSpecificationLibrary
    {
        private readonly IKolaConfigurationRegistry registry;

        public ParameterSpecificationLibrary(IKolaConfigurationRegistry registry)
        {
            this.registry = registry;
        }

        public IEnumerable<ParameterTypeSpecification> FindAll()
        {
            return this.registry.KolaConfiguration.Plugins.SelectMany(plugin => plugin.ParameterTypeSpecifications);
        }

        public ParameterTypeSpecification Find(string name)
        {
            return this.registry.KolaConfiguration.Plugins
                .SelectMany(plugin => plugin.ParameterTypeSpecifications)
                .FirstOrDefault(c => c.Name == name);

        }
    }
}