namespace Kola.Configuration.Fluent
{
    using Kola.Domain.Specifications;
    using Kola.Domain.Templates;

    public class ComponentRendererConfigurer
    {
        private readonly IPluginComponentSpecification<INamedComponentTemplate> configuration;

        internal ComponentRendererConfigurer(IPluginComponentSpecification<INamedComponentTemplate> componentConfiguration)
        {
            this.configuration = componentConfiguration;
        }

        public CacheConfigurer Cache
        {
            get { return new CacheConfigurer(this.configuration); }
        }

        public ComponentRendererConfigurer WithParameter(string parameterName, string parameterType)
        {
            this.configuration.AddParameter(new ParameterSpecification(parameterName, parameterType));
            return this;
        }

    }
}