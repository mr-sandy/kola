
namespace Kola.Configuration.Fluent
{
    using Kola.Domain;

    public class ComponentHandlerConfigurer
    {
        private readonly PluginComponentSpecification configuration;

        internal ComponentHandlerConfigurer(PluginComponentSpecification componentConfiguration)
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