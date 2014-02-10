namespace Kola.Domain.Specifications
{
    using System;

    using Kola.Domain.Templates;

    public abstract class PluginComponentSpecification<T> : NamedComponentSpecification<T>, IPluginComponentSpecification<T>
        where T : INamedComponentTemplate
    {
        protected PluginComponentSpecification(string name)
            : base(name)
        {
        }

        public Type RendererType { get; set; }

        public CacheType CacheType { get; set; }

        public int CacheDuration { get; set; }

        public string ViewName { get; set; }

        public override abstract T Create();
    }
}