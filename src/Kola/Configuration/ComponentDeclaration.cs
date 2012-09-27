namespace Kola.Configuration
{
    public abstract class ComponentDeclaration
    {
        private readonly PluginConfiguration pluginConfiguration;
        private readonly ComponentConfiguration behaviourConfiguration;

        internal ComponentDeclaration(PluginConfiguration pluginConfiguration)
        {
            this.pluginConfiguration = pluginConfiguration;
            behaviourConfiguration = new ComponentConfiguration(this);
        }

        public ComponentConfiguration WithHandler<T>(string view = "")
            where T : Handler
        {
            return this.behaviourConfiguration;
        }

        public ComponentConfiguration WithView(string view)
        {
            return this.WithHandler<DefaultHandler>(view);
        }
    }
}