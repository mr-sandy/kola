using System;
using System.Collections.Generic;
using Kola.Configuration;
using Kola.Model;

namespace Kola.Processing
{
    public class HandlerFactory : IHandlerFactory
    {
        private readonly IDictionary<string, Type> handlerMappings;
        private readonly IObjectFactory objectFactory;

        public HandlerFactory(IDictionary<string, Type> handlerMappings, IObjectFactory objectFactory)
        {
            this.handlerMappings = handlerMappings;
            this.objectFactory = objectFactory;
        }

        public IHandler GetHandler(IComponent component)
        {
            if (this.handlerMappings.ContainsKey(component.Name))
            {
                var handlerType = handlerMappings[component.Name];
                return this.objectFactory.Resolve<IHandler>(handlerType);
            }

            return null;
        }
    }

    public interface IObjectFactory
    {
        T Resolve<T>(Type type);
    }
}