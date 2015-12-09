namespace Kola.Domain.Specifications
{
    using System;

    using Kola.Domain.Composition;

    public abstract class PluginComponentSpecification<T> : ComponentSpecification<T>, IPluginComponentSpecification<T>
        where T : IComponentWithProperties
    {
        protected PluginComponentSpecification(string name)
            : base(name)
        {
        }

        public Type RendererType { get; set; }

        public CacheType CacheType { get; set; }

        public int CacheDuration { get; set; }

        public string ViewName { get; set; }

        public abstract override T Create();
    }
}