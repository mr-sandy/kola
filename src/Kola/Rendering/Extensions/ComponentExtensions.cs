namespace Kola.Rendering.Extensions
{
    using System;
    using System.Collections.Generic;

    using Kola.Domain;

    internal static class ComponentExtensions
    {
        public static Page ToPage(this Template template)
        {
            var visitor = new ComponentInstanceBuilingVisitor();

            foreach (var component in template.Components)
            {
                component.Accept(visitor);
            }

            return new Page(visitor.Components);
        }

        public static ComponentInstance ToInstance(this Atom atom)
        {
            return new ComponentInstance(atom.Name);
        }

        public static ComponentInstance ToInstance(this Container container)
        {
            var visitor = new ComponentInstanceBuilingVisitor();

            foreach (var component in container.Components)
            {
                component.Accept(visitor);
            }

            return new ComponentInstance(container.Name, visitor.Components);
        }
    }

    internal class ComponentInstanceBuilingVisitor : IComponentVisitor
    {
        private readonly List<IComponentInstance> components = new List<IComponentInstance>();

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
            this.components.Add(container.ToInstance());
        }
    }
}
