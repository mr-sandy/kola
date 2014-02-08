namespace Kola.Configuration.Fluent
{
    using Kola.Domain.Specifications;
    using Kola.Domain.Templates;

    public class ComponentRendererConfigurer
    {
        private readonly IPluginComponentSpecification<IComponentTemplate> configuration;

        internal ComponentRendererConfigurer(IPluginComponentSpecification<IComponentTemplate> componentConfiguration)
        {
            this.configuration = componentConfiguration;
        }

        public ComponentRendererConfigurer WithParameter(string parameterName, string parameterType)
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