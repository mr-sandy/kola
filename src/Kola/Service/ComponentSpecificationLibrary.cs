namespace Kola.Service
{
    using System.Collections.Generic;
    using System.Linq;

    using Kola.Configuration;
    using Kola.Domain.Composition;
    using Kola.Domain.Specifications;
    using Kola.Persistence;

    public class ComponentSpecificationLibrary : IComponentSpecificationLibrary
    {
        private readonly IKolaConfigurationRegistry registry;

        private readonly IWidgetSpecificationRepository widgetRepository;

        public ComponentSpecificationLibrary(IKolaConfigurationRegistry registry, IWidgetSpecificationRepository widgetRepository)
        {
            this.registry = registry;
            this.widgetRepository = widgetRepository;
        }

        public IEnumerable<IComponentSpecification<IParameterisedComponent>> FindAll()
        {
            IEnumerable<IComponentSpecification<IParameterisedComponent>> pluggedInComponents = this.registry.KolaConfiguration.Plugins
                .SelectMany(plugin => plugin.ComponentTypeSpecifications);

            var widgets = this.widgetRepository.FindAll();

            return pluggedInComponents.Concat(widgets);
        }

        public IComponentSpecification<IParameterisedComponent> Lookup(string componentName)
        {
            var componentSpecification = this.registry.KolaConfiguration.Plugins
                .SelectMany(plugin => plugin.ComponentTypeSpecifications)
                .FirstOrDefault(c => c.Name == componentName);

            return componentSpecification != null
                ? (IComponentSpecification<IParameterisedComponent>)componentSpecification
                : this.widgetRepository.Find(componentName);
        }
    }
}