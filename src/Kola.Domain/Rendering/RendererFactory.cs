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
        private readonly IContainer container;

        public RendererFactory(IEnumerable<IPluginComponentSpecification<IComponentWithProperties>> componentSpecifications, IContainer container)
        {
            this.componentSpecifications = componentSpecifications;
            this.container = container;
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
                return this.container.Resolve<IRenderer<T>>(specification.RendererType, specification);
            }

            throw new Exception("No renderer found for component '" + componentName + "'");
        }
    }
}