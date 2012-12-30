using System;
using Kola.Configuration;
using Kola.Model;

namespace Kola.Processing
{
    public class CachingHandlerFactory : IHandlerFactory
    {
        private readonly IHandlerFactory innerHandlerFactory;

        public CachingHandlerFactory(IHandlerFactory innerHandlerFactory)
        {
            this.innerHandlerFactory = innerHandlerFactory;
        }

        public IHandler GetHandler(IComponent component)
        {
            return this.Retrieve(component)
                   ?? this.Cache(this.innerHandlerFactory.GetHandler(component));
        }

        private IHandler Cache(IHandler handler)
        {
            //Add to cache...

            return handler;
        }

        private IHandler Retrieve(IComponent component)
        {
            //Lookup cache

            return null;
        }
    }
}