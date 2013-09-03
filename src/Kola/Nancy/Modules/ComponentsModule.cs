namespace Kola.Nancy.Modules
{
    using global::Nancy;

    public class ComponentsModule : NancyModule
    {

        public ComponentsModule()
        {
            this.Get["/_kola/components", AcceptHeaderFilters.NotHtml] = p => this.GetComponents();
        }

        private dynamic GetComponents()
        {
            return new[]
                {
                    new { name = "component 1" }, 
                    new { name = "component 2" }, 
                    new { name = "component 3" }
                };
        }
    }
}