
namespace Kola.Configuration.Plugins
{
    public class CacheConfigurer
    {
        private readonly AtomConfiguration atomConfiguration;

        internal CacheConfigurer(AtomConfiguration atomConfiguration)
        {
            this.atomConfiguration = atomConfiguration;
        }

        public CacheConfigurer PerUser
        {
            get
            {
                this.atomConfiguration.CacheType = CacheType.PerUser;
                return this;
            }
        }

        public CacheConfigurer For(int seconds)
        {
            this.atomConfiguration.CacheDuration = seconds;
            return this;
        }
    }
}