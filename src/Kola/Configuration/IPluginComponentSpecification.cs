namespace Kola.Configuration
{
    using System;
    using System.Collections.Generic;

    using Kola.Domain;

    public interface IPluginComponentSpecification : IComponentSpecification
    {
        Type HandlerType { get; }

        string ViewName { get; }

        IEnumerable<ParameterSpecification> Parameters { get; }

        CacheType CacheType { get; }

        int CacheDuration { get; }
    }
}