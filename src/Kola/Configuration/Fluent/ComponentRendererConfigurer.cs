namespace Kola.Configuration.Fluent
{
    using Kola.Domain.Composition;
    using Kola.Domain.Specifications;

    public class ComponentRendererConfigurer
    {
        private readonly IPluginComponentSpecification<IParameterisedComponent> specification;

        internal ComponentRendererConfigurer(IPluginComponentSpecification<IParameterisedComponent> specification)
        {
            this.specification = specification;
        }

        public CacheConfigurer Cache
        {
            get { return new CacheConfigurer(this.specification); }
        }

        public ComponentRendererConfigurer WithParameter(string parameterName, string parameterType)
        {
            this.specification.AddParameter(new ParameterSpecification(parameterName, parameterType));
            return this;
        }
    }
}