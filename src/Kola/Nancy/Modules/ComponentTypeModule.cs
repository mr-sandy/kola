namespace Kola.Nancy.Modules
{
    using Kola.Configuration;
    using Kola.Extensions;
    using Kola.Persistence;

    using global::Nancy;

    public class ComponentTypeModule : NancyModule
    {
        private readonly IComponentTypeRegistry componentTypeRepository;

        public ComponentTypeModule(IComponentTypeRegistry componentTypeRepository)
        {
            this.componentTypeRepository = componentTypeRepository;
            this.Get["/_kola/component-types", AcceptHeaderFilters.NotHtml] = p => this.GetComponentTypes();
        }

        private dynamic GetComponentTypes()
        {
            var componentTypes = this.componentTypeRepository.FindAll();

            return this.Negotiate.WithModel(componentTypes.ToResource());
        }
    }
}