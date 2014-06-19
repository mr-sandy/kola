namespace Kola.Nancy.Modules
{
    using Kola.Domain;
    using Kola.Domain.Composition;
    using Kola.Extensions;

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

            return this.Negotiate
                .WithAllowedMediaRange("application/json")
                .WithModel(componentTypes.ToResource());
        }
    }
}