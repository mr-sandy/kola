
namespace Kola.Configuration.Plugins
{
    public class AtomHandlerConfigurer
    {
        private readonly AtomConfiguration atomConfiguration;

        internal AtomHandlerConfigurer(AtomConfiguration atomConfiguration)
        {
            this.atomConfiguration = atomConfiguration;
        }

        public AtomHandlerConfigurer WithParameter(string parameterName, string parameterType, string parameterValue = "")
        {
            this.atomConfiguration.ConfigureParameter(parameterName, parameterType, parameterValue);
            return this;
        }

        public CacheConfigurer Cache
        {
            get { return new CacheConfigurer(this.atomConfiguration); }
        }
    }
}