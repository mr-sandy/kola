namespace Kola.Persistence
{
    using System;
    using System.Collections.Generic;

    using Kola.Domain;
    using Kola.Persistence.Extensions;
    using Kola.Persistence.Surrogates;

    internal class ComponentSurrogateBuildingVisitor : IComponentVisitor
    {
        private readonly List<ComponentSurrogate> componentSurrogates = new List<ComponentSurrogate>();

        public IEnumerable<ComponentSurrogate> ComponentSurrogates
        {
            get { return this.componentSurrogates; }
        }

        public void Visit(Container component)
        {
            this.componentSurrogates.Add(component.ToSurrogate());
        }

        public void Visit(Widget widget)
        {
            this.componentSurrogates.Add(widget.ToSurrogate());
        }

        public void Visit(Atom component)
        {
            this.componentSurrogates.Add(component.ToSurrogate());
        }
    }
}