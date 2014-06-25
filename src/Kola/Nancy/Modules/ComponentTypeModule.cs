namespace Kola.Nancy.Modules
{
    using Kola.Domain.Composition;
    using Kola.ResourceBuilding;

    using global::Nancy;

    public class ComponentTypeModule : NancyModule
    {
        private readonly IComponentSpecificationLibrary componentLibrary;

        public ComponentTypeModule(IComponentSpecificationLibrary componentLibrary)
        {
            this.componentLibrary = componentLibrary;
            this.Get["/_kola/component-types", AcceptHeaderFilters.NotHtml] = p => this.GetComponentTypes();
        }

        private dynamic GetComponentTypes()
        {
            var componentTypes = this.componentLibrary.FindAll();

            var resource = new ComponentTypeResourceBuilder().Build(componentTypes);

            return this.Negotiate
                .WithModel(resource)
                .WithAllowedMediaRange("application/json");
        }
    }
}