namespace Kola.Domain.Rendering
{
    using System;

    using Kola.Domain.Composition;
    using Kola.Domain.Specifications;

    public interface IObjectFactory
    {
        T Resolve<T>(Type type);

        T Resolve<T>(Type type, IPluginComponentSpecification<IComponentWithProperties> specification);

        //void Register<TType, TRegistration>() 
        //    where TType : class 
        //    where TRegistration : class, TType;

        //void Register<TType, TRegistration>(TRegistration instance) 
        //    where TType : class 
        //    where TRegistration : class, TType;

        void Register<T>(Func<T> constructor) where T : class;
    }
}