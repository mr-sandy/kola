
namespace Kola.Configuration.Fluent
{
    public class ComponentHandlerConfigurer
    {
        private readonly ComponentConfiguration configuration;

        internal ComponentHandlerConfigurer(ComponentConfiguration componentConfiguration)
        {
            this.configuration = componentConfiguration;
        }

        public ComponentHandlerConfigurer WithParameter(string parameterName, string parameterType, string parameterValue = "")
        {
            this.configuration.AddParameter(new ParameterConfiguration(parameterName, parameterType, parameterValue));
            return this;
        }

        public CacheConfigurer Cache
        {
            get { return new CacheConfigurer(this.configuration); }
        }
    }
}