namespace Kola.Nancy
{
    using System.Collections.Generic;
    using System.Linq;

    using Kola.Configuration;
    using Kola.Domain;
    using Kola.Persistence;

    public class ComponentLibrary : IComponentLibrary
    {
        private readonly IKolaConfigurationRegistry registry;

        private readonly IWidgetSpecificationRepository widgetRepository;

        public ComponentLibrary(IKolaConfigurationRegistry registry, IWidgetSpecificationRepository widgetRepository)
        {
            this.registry = registry;
            this.widgetRepository = widgetRepository;
        }

        public IEnumerable<IComponentSpecification> FindAll()
        {
            var pluggedInComponents = this.registry.KolaConfiguration.Plugins
                .SelectMany(plugin => plugin.Components);

            var widgets = this.widgetRepository.FindAll();

            return pluggedInComponents.Concat<IComponentSpecification>(widgets);
        }

        public IComponentSpecification Lookup(string componentName)
        {
            var component = this.registry.KolaConfiguration.Plugins
                .SelectMany(plugin => plugin.Components)
                .FirstOrDefault(c => c.Name == componentName);

            return component != null 
                ? (IComponentSpecification)component 
                : this.widgetRepository.Find(componentName);
        }
    }
}