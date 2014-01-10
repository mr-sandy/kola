namespace Kola.Nancy
{
    using System.Collections.Generic;
    using System.Linq;

    using Kola.Domain;
    using Kola.Persistence;

    public class ComponentLibrary : IComponentLibrary
    {
        private readonly IWidgetSpecificationRepository widgetRepository;

        public ComponentLibrary(IWidgetSpecificationRepository widgetRepository)
        {
            this.widgetRepository = widgetRepository;
        }

        public IEnumerable<IComponentSpecification> FindAll()
        {
            var pluggedInComponents = NancyKolaRegistry.KolaConfiguration.Plugins
                .SelectMany(plugin => plugin.Components);

            var widgets = this.widgetRepository.FindAll();

            return pluggedInComponents.Concat<IComponentSpecification>(widgets);
        }

        public IComponentSpecification Lookup(string componentName)
        {
            var component = NancyKolaRegistry.KolaConfiguration.Plugins
                .SelectMany(plugin => plugin.Components)
                .FirstOrDefault(c => c.Name == componentName);

            return component != null 
                ? (IComponentSpecification)component 
                : this.widgetRepository.Find(componentName);
        }
    }
}