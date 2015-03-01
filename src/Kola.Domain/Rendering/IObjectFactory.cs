namespace Kola.Domain.Rendering
{
    using System;

    using Kola.Domain.Composition;
    using Kola.Domain.Specifications;

    public interface IObjectFactory
    {
        T Resolve<T>(Type type);

        T Resolve<T>(Type type, IPluginComponentSpecification<IComponentWithProperties> specification);
    }
}