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

        public IHandler GetHandler(string componentName)
        {
            if (this.handlerMappings.ContainsKey(componentName))
            {
                var handlerType = this.handlerMappings[componentName];
                return this.objectFactory.Resolve<IHandler>(handlerType);
            }

            throw new Exception("No handler found for component '" + componentName + "'");
        }
    }
}