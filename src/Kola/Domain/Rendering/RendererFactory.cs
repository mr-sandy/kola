namespace Kola.Domain.Rendering
{
    using System;
    using System.Collections.Generic;

    using Kola.Domain.Instances;

    public class RendererFactory : IRendererFactory
    {
        private readonly IDictionary<string, Type> rendererMappings;
        private readonly IObjectFactory objectFactory;

        public RendererFactory(IDictionary<string, Type> rendererMappings, IObjectFactory objectFactory)
        {
            this.rendererMappings = rendererMappings;
            this.objectFactory = objectFactory;
        }

        public IRenderer<AtomInstance> GetAtomRenderer(string atomName)
        {
            if (this.rendererMappings.ContainsKey(atomName))
            {
                var rendererType = this.rendererMappings[atomName];
                return this.objectFactory.Resolve<IRenderer<AtomInstance>>(rendererType);
            }

            throw new Exception("No renderer found for component '" + atomName + "'");
        }

        public IRenderer<ContainerInstance> GetContainerRenderer(string containerName)
        {
            if (this.rendererMappings.ContainsKey(containerName))
            {
                var rendererType = this.rendererMappings[containerName];
                return this.objectFactory.Resolve<IRenderer<ContainerInstance>>(rendererType);
            }

            throw new Exception("No renderer found for component '" + containerName + "'");
        }
    }
}