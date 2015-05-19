namespace Sample.Plugin
{
    using Kola.Configuration.Plugins;

    public class Configuration : PluginConfiguration
    {
        public Configuration()
            : base("Sample")
        {
            this.Configure.ViewLocation("Sample.Plugin.Views");

            this.ConfigureAtoms();

            this.ConfigureContainers();

            this.ConfigurePropertyTypes();
        }

        private void ConfigureAtoms()
        {
        }

        private void ConfigureContainers()
        {
            this.Configure.Container("div")
                .WithView("Div")
                .WithProperty("classes", "text");
        }

        private void ConfigurePropertyTypes()
        {
        }
    }
}
