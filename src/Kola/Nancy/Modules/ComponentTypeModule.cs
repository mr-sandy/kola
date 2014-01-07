namespace Kola.Nancy.Modules
{
    using Kola.Extensions;

    using global::Nancy;

    public class ComponentTypeModule : NancyModule
    {
        private readonly IComponentRegistry componentTypeRepository;

        public ComponentTypeModule(IComponentRegistry componentTypeRepository)
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