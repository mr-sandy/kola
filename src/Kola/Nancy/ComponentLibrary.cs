namespace Kola.Nancy
{
    using System.Collections.Generic;
    using System.Linq;

    using Kola.Domain;

    public class ComponentLibrary : IComponentLibrary
    {
        public IEnumerable<IComponentSpecification> FindAll()
        {
            return NancyKolaRegistry.KolaConfiguration.Plugins
                .SelectMany(plugin => plugin.Components);
        }

        public IComponentSpecification Lookup(string componentName)
        {
            return NancyKolaRegistry.KolaConfiguration.Plugins
                .SelectMany(plugin => plugin.Components)
                .FirstOrDefault(component => component.Name == componentName);
        }
    }
}