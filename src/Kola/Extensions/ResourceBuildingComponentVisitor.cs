namespace Kola.Extensions
{
    using System;
    using System.Collections.Generic;

    using Kola.Domain.Composition;
    using Kola.Resources;

    internal class ResourceBuildingComponentVisitor : IComponentVisitor
    {
        private readonly List<ComponentResource> componentResources = new List<ComponentResource>();

        public IEnumerable<ComponentResource> ComponentResources
        {
            get { return this.componentResources; }
        }

        public void Visit(Atom atom)
        {
            this.componentResources.Add(new ComponentResource
                {
                    Name = atom.Name
                });
        }

        public void Visit(Container container)
        {
            this.componentResources.Add(new ComponentResource
            {
                Name = container.Name
            });
        }

        public void Visit(Widget widget)
        {
            this.componentResources.Add(new ComponentResource
            {
                Name = widget.Name
            });
        }

        public void Visit(Placeholder placeholder)
        {
            this.componentResources.Add(new ComponentResource
            {
                Name = "placeholder"
            });
        }
    }
}