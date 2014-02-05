namespace Kola.Rendering
{
    using System;
    using System.Collections.Generic;

    using Kola.Domain.Instances;

    public class HandlerFactory : IHandlerFactory
    {
        private readonly IDictionary<string, Type> handlerMappings;
        private readonly IObjectFactory objectFactory;

        public HandlerFactory(IDictionary<string, Type> handlerMappings, IObjectFactory objectFactory)
        {
            this.handlerMappings = handlerMappings;
            this.objectFactory = objectFactory;
        }

        public IHandler<AtomInstance> GetAtomHandler(string atomName)
        {
            if (this.handlerMappings.ContainsKey(atomName))
            {
                var handlerType = this.handlerMappings[atomName];
                return this.objectFactory.Resolve<IHandler<AtomInstance>>(handlerType);
            }

            throw new Exception("No handler found for component '" + atomName + "'");
        }

        public IHandler<ContainerInstance> GetContainerHandler(string containerName)
        {
            if (this.handlerMappings.ContainsKey(containerName))
            {
                var handlerType = this.handlerMappings[containerName];
                return this.objectFactory.Resolve<IHandler<ContainerInstance>>(handlerType);
            }

            throw new Exception("No handler found for component '" + containerName + "'");
        }
    }
}