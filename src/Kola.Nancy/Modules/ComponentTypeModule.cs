namespace Kola.Nancy.Modules
{
    using System.Linq;

    using Kola.Domain.Composition;

    using global::Nancy;

    using Kola.Service.ResourceBuilding;

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

            var resource = new ComponentTypeResourceBuilder().Build(componentTypes).OrderBy(c => c.Type).ThenBy(c => c.Name);

            return this.Negotiate
                .WithModel(resource)
                .WithAllowedMediaRange("application/json");
        }
    }
}