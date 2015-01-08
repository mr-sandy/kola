namespace Kola.Configuration.Fluent
{
    using Kola.Domain.Composition;
    using Kola.Domain.Specifications;

    public class ComponentRendererConfigurer
    {
        private readonly IPluginComponentSpecification<IComponentWithProperties> specification;

        internal ComponentRendererConfigurer(IPluginComponentSpecification<IComponentWithProperties> specification)
        {
            this.specification = specification;
        }

        public CacheConfigurer Cache
        {
            get { return new CacheConfigurer(this.specification); }
        }

        public ComponentRendererConfigurer WithProperty(string propertyName, string propertyType)
        {
            this.specification.AddProperty(new PropertySpecification(propertyName, propertyType));
            return this;
        }
    }
}