namespace Kola.Processing
{
    using System;
    using System.Collections.Generic;

    using Kola.Domain;

    public class HandlerFactory : IHandlerFactory
    {
        private readonly IDictionary<string, Type> handlerMappings;
        private readonly IObjectFactory objectFactory;

        public HandlerFactory(IDictionary<string, Type> handlerMappings, IObjectFactory objectFactory)
        {
            this.handlerMappings = handlerMappings;
            this.objectFactory = objectFactory;
        }

        public IHandler GetHandler(Component component)
        {
            if (this.handlerMappings.ContainsKey(component.Name))
            {
                var handlerType = this.handlerMappings[component.Name];
                return this.objectFactory.Resolve<IHandler>(handlerType);
            }

            throw new Exception("No handler found for component '" + component.Name + "'");
        }
    }
}