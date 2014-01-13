namespace Kola.Rendering.Extensions
{
    using System;

    using Kola.Domain;
    using Kola.Persistence;

    internal static class ComponentExtensions
    {
        public static Page ToPage(this Template template, IWidgetSpecificationRepository widgetSpecificationRepository)
        {
            var visitor = new ComponentInstanceBuildingVisitor(widgetSpecificationRepository);

            foreach (var component in template.Components)
            {
                component.Accept(visitor);
            }

            return new Page(visitor.Components);
        }

        public static AtomInstance ToInstance(this Atom atom)
        {
            return new AtomInstance(atom.Name);
        }

        public static ContainerInstance ToInstance(this Container container, IWidgetSpecificationRepository widgetSpecificationRepository)
        {
            var visitor = new ComponentInstanceBuildingVisitor(widgetSpecificationRepository);

            foreach (var component in container.Components)
            {
                component.Accept(visitor);
            }

            return new ContainerInstance(container.Name, visitor.Components);
        }

        public static WidgetInstance ToInstance(this Widget widget, IWidgetSpecificationRepository widgetSpecificationRepository)
        {
            var specification = widgetSpecificationRepository.Find(widget.Name);

            var visitor = new ComponentInstanceBuildingVisitor(widgetSpecificationRepository);

            foreach (var component in specification.Components)
            {
                component.Accept(visitor);
            }

            return new WidgetInstance(widget.Name, visitor.Components);
        }
    }
}
