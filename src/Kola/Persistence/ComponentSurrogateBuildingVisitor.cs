namespace Kola.Persistence
{
    using System.Collections.Generic;

    using Kola.Editing;
    using Kola.Persistence.Extensions;
    using Kola.Persistence.Surrogates;

    internal class ComponentSurrogateBuildingVisitor : IComponentVisitor
    {
        private readonly List<ComponentSurrogate> componentSurrogates = new List<ComponentSurrogate>();

        public IEnumerable<ComponentSurrogate> ComponentSurrogates
        {
            get { return this.componentSurrogates; }
        }

        public void Visit(CompositeComponent component)
        {
            this.componentSurrogates.Add(component.ToSurrogate());
        }

        public void Visit(SimpleComponent component)
        {
            this.componentSurrogates.Add(component.ToSurrogate());
        }
    }
}