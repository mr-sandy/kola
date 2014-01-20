
namespace Kola.Configuration.Fluent
{
    using Kola.Domain;
    using Kola.Domain.Specifications;
    using Kola.Domain.Templates;

    public class CacheConfigurer
    {
        private readonly IPluginComponentSpecification<IComponent> componentConfiguration;

        internal CacheConfigurer(IPluginComponentSpecification<IComponent> componentConfiguration)
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