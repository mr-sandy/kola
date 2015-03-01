
namespace Kola.Configuration.Fluent
{
    using Kola.Domain;
    using Kola.Domain.Specifications;
    using Kola.Domain.Composition;

    public class CacheConfigurer
    {
        private readonly IPluginComponentSpecification<IComponentWithProperties> componentConfiguration;

        internal CacheConfigurer(IPluginComponentSpecification<IComponentWithProperties> componentConfiguration)
        {
            this.componentConfiguration = componentConfiguration;
        }

        public CacheConfigurer Cache
        {
            get
            {
                this.componentConfiguration.CacheType = CacheType.Cache;
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