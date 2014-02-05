namespace Kola.Persistence
{
    using System.Collections.Generic;

    using Kola.Domain.Templates;
    using Kola.Persistence.Extensions;
    using Kola.Persistence.Surrogates;

    internal class ComponentSurrogateBuildingVisitor : IComponentTemplateVisitor
    {
        private readonly List<ComponentSurrogate> componentSurrogates = new List<ComponentSurrogate>();

        public IEnumerable<ComponentSurrogate> ComponentSurrogates
        {
            get { return this.componentSurrogates; }
        }

        public void Visit(ContainerTemplate container)
        {
            this.componentSurrogates.Add(container.ToSurrogate());
        }

        public void Visit(WidgetTemplate widget)
        {
            this.componentSurrogates.Add(widget.ToSurrogate());
        }

        public void Visit(PlaceholderTemplate placeholder)
        {
            this.componentSurrogates.Add(placeholder.ToSurrogate());
        }

        public void Visit(AtomTemplate atom)
        {
            this.componentSurrogates.Add(atom.ToSurrogate());
        }
    }
}