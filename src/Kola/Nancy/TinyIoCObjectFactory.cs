namespace Kola.Nancy
{
    using System;

    using Kola.Processing;

    using global::Nancy.TinyIoc;

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
    }
}