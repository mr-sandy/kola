
namespace Kola.Configuration.Fluent
{
    public class CacheConfigurer
    {
        private readonly ComponentConfiguration componentConfiguration;

        internal CacheConfigurer(ComponentConfiguration componentConfiguration)
        {
            this.componentConfiguration = componentConfiguration;
        }

        public CacheConfigurer PerUser
        {
            get
            {
                this.componentConfiguration.CacheType = CacheType.PerUser;
                return this;
            }
        }

        public CacheConfigurer For(int seconds)
        {
            this.componentConfiguration.CacheDuration = seconds;
            return this;
        }
    }
}