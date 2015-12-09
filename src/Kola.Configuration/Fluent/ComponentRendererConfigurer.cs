namespace Kola.Configuration.Fluent
{
    using System;

    using Kola.Domain.Composition;
    using Kola.Domain.Specifications;

    public class ComponentRendererConfigurer
    {
        private readonly IPluginComponentSpecification<IComponentWithProperties> specification;

        internal ComponentRendererConfigurer(IPluginComponentSpecification<IComponentWithProperties> specification)
        {
            this.specification = specification;
        }

        public CacheConfigurer Cache => new CacheConfigurer(this.specification);

        public ComponentRendererConfigurer WithProperty(string propertyName, string propertyType, string defaultValue = "")
        {
            this.specification.AddProperty(new PropertySpecification(propertyName, propertyType, defaultValue));
            return this;
        }

        public ComponentRendererConfigurer ExtendWith(Action<ComponentRendererConfigurer> configure)
        {
            configure(this);

            return this;
        }
    }
}