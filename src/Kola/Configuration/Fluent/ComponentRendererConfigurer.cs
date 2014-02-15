namespace Kola.Configuration.Fluent
{
    using Kola.Domain.Specifications;
    using Kola.Domain.Composition;

    public class ComponentRendererConfigurer
    {
        private readonly IPluginComponentSpecification<IParameterisedComponent> configuration;

        internal ComponentRendererConfigurer(IPluginComponentSpecification<IParameterisedComponent> componentConfiguration)
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