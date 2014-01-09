namespace Kola.Nancy.Modules
{
    using Kola.Domain;
    using Kola.Extensions;

    using global::Nancy;

    public class ComponentTypeModule : NancyModule
    {
        private readonly IComponentLibrary componentLibrary;

        public ComponentTypeModule(IComponentLibrary componentLibrary)
        {
            this.componentLibrary = componentLibrary;
            this.Get["/_kola/component-types", AcceptHeaderFilters.NotHtml] = p => this.GetComponentTypes();
        }

        private dynamic GetComponentTypes()
        {
            var componentTypes = this.componentLibrary.FindAll();

            return this.Negotiate.WithModel(componentTypes.ToResource());
        }
    }
}