namespace Kola.Configuration
{
    using System.Collections.Generic;

    using Kola.Editing;

    public class ComponentTypeRegistry : IComponentTypeRegistry
    {
        public IEnumerable<ComponentType> FindAll()
        {
            foreach (var pluginSummary in Kola.Nancy.NancyKolaRegistry.KolaConfiguration.PluginSummaries)
            {
                
            }
            return new[]
                {
                    new ComponentType("Component Type 1"), 
                    new ComponentType("Component Type 2"),
                    new ComponentType("Component Type 3")
                };
        }
    }
}