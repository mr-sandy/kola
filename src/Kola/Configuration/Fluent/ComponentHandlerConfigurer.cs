
namespace Kola.Configuration.Fluent
{
    using Kola.Domain;

    public class ComponentHandlerConfigurer
    {
        private readonly IPluginComponentSpecification<IComponent> configuration;

        internal ComponentHandlerConfigurer(IPluginComponentSpecification<IComponent> componentConfiguration)
        {
            this.configuration = componentConfiguration;
        }

        public ComponentHandlerConfigurer WithParameter(string parameterName, string parameterType)
        {
            this.configuration.AddParameter(new ParameterSpecification(parameterName, parameterType));
            return this;
        }

        public CacheConfigurer Cache
        {
            get { return new CacheConfigurer(this.configuration); }
        }
    }
}