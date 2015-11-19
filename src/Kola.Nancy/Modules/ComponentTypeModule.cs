namespace Kola.Nancy.Modules
{
    using global::Nancy;

    using Kola.Service.Services;

    public class ComponentTypeModule : NancyModule
    {
        private readonly IComponentSpecificationService componentSpecificationService;

        public ComponentTypeModule(IComponentSpecificationService componentSpecificationService)
        {
            this.componentSpecificationService = componentSpecificationService;

            this.Get["/_kola/component-types"] = p => this.GetComponentTypes();
        }

        private dynamic GetComponentTypes()
        {
            return this.componentSpecificationService.GetComponentSpecifications();
        }
    }
}
