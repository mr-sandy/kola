
namespace Kola.Configuration.Fluent
{
    using Kola.Configuration.Plugins;
    using Kola.Domain;
    using Kola.Domain.Specifications;
    using Kola.Domain.Templates;

    public class PluginConfigurer
    {
        private readonly PluginConfiguration configuration;

        internal PluginConfigurer(PluginConfiguration pluginConfiguration)
        {
            this.configuration = pluginConfiguration;
        }

        public void ViewLocation(string viewLocation)
        {
            this.configuration.ViewLocation = viewLocation;
        }

        public ComponentConfigurer Container(string componentName)
        {
            IPluginComponentSpecification<IComponent> componentSpecification = new ContainerSpecification(componentName);

            this.configuration.Add(componentSpecification);

            return new ComponentConfigurer(componentSpecification);
        }

        public ComponentConfigurer Atom(string componentName)
        {
            var componentSpecification = new AtomSpecification(componentName);

            this.configuration.Add(componentSpecification);

            return new ComponentConfigurer(componentSpecification);
        }

        public ParameterTypeConfigurer ParameterType(string parameterName)
        {
            var parameterTypeSpecification = new ParameterTypeSpecification(parameterName);

            this.configuration.Add(parameterTypeSpecification);

            return new ParameterTypeConfigurer(parameterTypeSpecification);
        }
    }
}