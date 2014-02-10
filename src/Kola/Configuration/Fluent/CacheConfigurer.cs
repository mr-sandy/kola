
namespace Kola.Configuration.Fluent
{
    using Kola.Domain;
    using Kola.Domain.Specifications;
    using Kola.Domain.Templates;

    public class CacheConfigurer
    {
        private readonly IPluginComponentSpecification<INamedComponentTemplate> componentConfiguration;

        internal CacheConfigurer(IPluginComponentSpecification<INamedComponentTemplate> componentConfiguration)
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