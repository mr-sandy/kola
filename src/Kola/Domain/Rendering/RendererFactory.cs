namespace Kola.Domain.Rendering
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Kola.Domain.Composition;
    using Kola.Domain.Instances;
    using Kola.Domain.Specifications;

    public class RendererFactory : IRendererFactory
    {
        private readonly IEnumerable<IPluginComponentSpecification<IComponentWithProperties>> componentSpecifications;
        private readonly IObjectFactory objectFactory;

        public RendererFactory(IEnumerable<IPluginComponentSpecification<IComponentWithProperties>> componentSpecifications, IObjectFactory objectFactory)
        {
            this.componentSpecifications = componentSpecifications;
            this.objectFactory = objectFactory;
        }

        public IRenderer<AtomInstance> GetAtomRenderer(string atomName)
        {
            return this.GetRenderer<AtomInstance>(atomName);
        }

        public IRenderer<ContainerInstance> GetContainerRenderer(string containerName)
        {
            return this.GetRenderer<ContainerInstance>(containerName);
        }

        private IRenderer<T> GetRenderer<T>(string componentName)
        {
            var specification = this.componentSpecifications.FirstOrDefault(s => s.Name == componentName);
            if (specification != null)
            {
                return this.objectFactory.Resolve<IRenderer<T>>(specification.RendererType);
            }

            throw new Exception("No renderer found for component '" + componentName + "'");
        }
    }
}