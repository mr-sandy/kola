
namespace Kola.Configuration.Fluent
{
    public class ComponentHandlerConfigurer
    {
        private readonly PluginComponentSpecification configuration;

        internal ComponentHandlerConfigurer(PluginComponentSpecification componentConfiguration)
        {
            this.configuration = componentConfiguration;
        }

        public ComponentHandlerConfigurer WithParameter(string parameterName, string parameterType, string parameterValue = "")
        {
            this.configuration.AddParameter(new ParameterSpecification(parameterName, parameterType, parameterValue));
            return this;
        }

        public CacheConfigurer Cache
        {
            get { return new CacheConfigurer(this.configuration); }
        }
    }
}