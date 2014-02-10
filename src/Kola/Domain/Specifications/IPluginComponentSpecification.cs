namespace Kola.Domain.Specifications
{
    using System;

    using Kola.Domain.Templates;

    public interface IPluginComponentSpecification<out T> : INamedComponentSpecification<T>
        where T : INamedComponentTemplate
    {
        Type RendererType { get; set; }

        CacheType CacheType { get; set; }

        int CacheDuration { get; set; }

        string ViewName { get; set;  }
    }
}