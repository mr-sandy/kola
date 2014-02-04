
namespace Kola.Configuration.Fluent
{
    using Kola.Domain;
    using Kola.Domain.Specifications;
    using Kola.Domain.Templates;

    public class ComponentHandlerConfigurer
    {
        private readonly IPluginComponentSpecification<IComponentTemplate> configuration;

        internal ComponentHandlerConfigurer(IPluginComponentSpecification<IComponentTemplate> componentConfiguration)
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