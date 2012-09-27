namespace Kola.Configuration
{
    public class ComponentConfiguration
    {
        private readonly ComponentDeclaration componentConfiguration;
        private CacheConfiguration cacheConfiguration;

        public ComponentConfiguration(ComponentDeclaration componentConfiguration)
        {
            this.componentConfiguration = componentConfiguration;
        }

        public CacheConfiguration Cache
        {
            get { return this.cacheConfiguration ?? (this.cacheConfiguration = new CacheConfiguration(this.componentConfiguration)); }
        }

        public ComponentConfiguration WithParameter(string parameterName, string parameterType, string parameterValue = "")
        {
            return this;
        }
    }
}