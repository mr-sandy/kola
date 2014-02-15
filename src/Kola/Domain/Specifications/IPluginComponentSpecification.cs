﻿namespace Kola.Domain.Specifications
{
    using System;

    using Kola.Domain.Composition;

    public interface IPluginComponentSpecification<out T> : IParameterisedComponentSpecification<T>
        where T : IParameterisedComponent
    {
        Type RendererType { get; set; }

        CacheType CacheType { get; set; }

        int CacheDuration { get; set; }

        string ViewName { get; set;  }
    }
}