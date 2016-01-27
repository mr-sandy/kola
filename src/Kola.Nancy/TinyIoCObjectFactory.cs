﻿namespace Kola.Nancy
{
    using System;

    using Kola.Domain.Composition;
    using Kola.Domain.Rendering;

    using global::Nancy.TinyIoc;

    using Kola.Domain.Specifications;

    public class TinyIoCObjectFactory : IObjectFactory
    {
        private readonly TinyIoCContainer container;

        public TinyIoCObjectFactory(TinyIoCContainer container)
        {
            this.container = container;
        }

        public T Resolve<T>(Type type)
        {
            return (T)this.container.Resolve(type);
        }

        public T Resolve<T>(Type type, IPluginComponentSpecification<IComponentWithProperties> specification)
        {
            var overloads = new NamedParameterOverloads
                {
                    { "specification", specification }
                };

            return (T)this.container.Resolve(type, overloads);
        }

        //public void Register<TType, TRegistration>() 
        //    where TType : class 
        //    where TRegistration : class, TType
        //{
        //    this.container.Register<TType, TRegistration>();
        //}

        //public void Register<TType, TRegistration>(TRegistration instance) 
        //    where TType : class 
        //    where TRegistration : class, TType
        //{
        //    this.container.Register<TType, TRegistration>(instance);
        //}

        public void Register<T>(Func<T> constructor) where T : class
        {
            this.container.Register((c, o) => constructor());
        }
    }
}