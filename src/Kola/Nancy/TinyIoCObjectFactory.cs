namespace Kola.Nancy
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
    }
}