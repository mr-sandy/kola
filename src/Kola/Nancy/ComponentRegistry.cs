namespace Kola.Nancy
{
    using System.Collections.Generic;
    using System.Linq;

    using Kola.Configuration;

    internal class ComponentRegistry : IComponentRegistry
    {
        public IEnumerable<ComponentSpecification> FindAll()
        {
            return NancyKolaRegistry.KolaConfiguration.Plugins.SelectMany(plugin => plugin.Components);
        }
    }
}