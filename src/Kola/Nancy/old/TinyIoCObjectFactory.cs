using System;
using Kola.Processing;
using Nancy.TinyIoc;

namespace Kola.Nancy
{
    using Kola.Processing.old;

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

        public void RegisterSingleton(Type type)
        {
            this.container.Register(type, type).AsSingleton();
        }
    }
}