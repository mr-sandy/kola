namespace Kola.Rendering
{
    using System;
    using System.Collections.Generic;

    public class HandlerFactory : IHandlerFactory
    {
        private readonly IDictionary<string, Type> handlerMappings;
        private readonly IObjectFactory objectFactory;

        public HandlerFactory(IDictionary<string, Type> handlerMappings, IObjectFactory objectFactory)
        {
            this.handlerMappings = handlerMappings;
            this.objectFactory = objectFactory;
        }

        public IHandler Create(string name)
        {
            if (this.handlerMappings.ContainsKey(name))
            {
                var handlerType = this.handlerMappings[name];
                return this.objectFactory.Resolve<IHandler>(handlerType);
            }

            throw new Exception("No handler found for component '" + name + "'");
        }
    }
}