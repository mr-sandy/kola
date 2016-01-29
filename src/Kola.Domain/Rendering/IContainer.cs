namespace Kola.Domain.Rendering
{
    using System;

    using Kola.Domain.Composition;
    using Kola.Domain.Specifications;

    public interface IContainer
    {
        T Resolve<T>(Type type);

        T Resolve<T>(string name) where T : class;

        T Resolve<T>(Type type, IPluginComponentSpecification<IComponentWithProperties> specification);

        void Register<TType, TRegistration>()
            where TType : class
            where TRegistration : class, TType;

        void Register<TType>(TType instance) where TType : class;

        void Register<T>(Func<T> constructor) where T : class;

        void Register<T>(Func<IContainer, T> constructor) where T : class;

        void Register<T>() where T : class;
    }
}