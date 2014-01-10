namespace Kola.Rendering
{
    using System;
    using System.Collections.Generic;

    using Kola.Domain;
    using Kola.Persistence;
    using Kola.Rendering.Extensions;

    internal class ComponentInstanceBuildingVisitor : IComponentVisitor
    {
        private readonly IWidgetSpecificationRepository widgetSpecificationRepository;

        private readonly List<IComponentInstance> components = new List<IComponentInstance>();

        public ComponentInstanceBuildingVisitor(IWidgetSpecificationRepository widgetSpecificationRepository)
        {
            this.widgetSpecificationRepository = widgetSpecificationRepository;
        }

        public IEnumerable<IComponentInstance> Components
        {
            get { return this.components; }
        }

        public void Visit(Atom atom)
        {
            this.components.Add(atom.ToInstance());
        }

        public void Visit(Container container)
        {
            this.components.Add(container.ToInstance(this.widgetSpecificationRepository));
        }

        public void Visit(Widget widget)
        {
            this.components.Add(widget.ToInstance(this.widgetSpecificationRepository));
        }
    }
}