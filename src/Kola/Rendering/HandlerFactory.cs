namespace Kola.Rendering
{
    using System;
    using System.Collections.Generic;

    using Kola.Configuration;
    using Kola.Domain;
    using Kola.Domain.Instances;

    public class HandlerFactory : IHandlerFactory, IComponentInstanceVisitor<IHandler>
    {
        private readonly IDictionary<string, Type> handlerMappings;
        private readonly IObjectFactory objectFactory;
        private readonly EngineLocator engineLocator;

        public HandlerFactory(IDictionary<string, Type> handlerMappings, IObjectFactory objectFactory, EngineLocator engineLocator)
        {
            this.handlerMappings = handlerMappings;
            this.objectFactory = objectFactory;
            this.engineLocator = engineLocator;
        }

        public IHandler Create(IComponentInstance component)
        {
            return component.Accept(this);
        }

        public IHandler Visit(AtomInstance atomInstance)
        {
            return this.GetHandler(atomInstance.Name);
        }

        public IHandler Visit(ContainerInstance containerInstance)
        {
            return this.GetHandler(containerInstance.Name);
        }

        public IHandler Visit(WidgetInstance widgetInstance)
        {
            return new WidgetHandler(this.engineLocator.Invoke());
        }

        public IHandler Visit(PlaceholderInstance placeholderInstance)
        {
            throw new NotImplementedException();
        }

        private IHandler GetHandler(string componentName)
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