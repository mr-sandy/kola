namespace Kola.Persistence
{
    using System.Collections.Generic;

    using Kola.Domain.Composition;
    using Kola.Persistence.Extensions;
    using Kola.Persistence.Surrogates;

    public class ComponentBuildingVisitor : IComponentSurrogateVisitor
    {
        private readonly List<IComponent> components = new List<IComponent>();

        public IEnumerable<IComponent> Components
        {
            get { return this.components; }
        }

        public void Visit(ContainerSurrogate surrogate)
        {
            this.components.Add(surrogate.ToDomain());
        }

        public void Visit(AtomSurrogate surrogate)
        {
            this.components.Add(surrogate.ToDomain());
        }

        public void Visit(WidgetSurrogate surrogate)
        {
            this.components.Add(surrogate.ToDomain());
        }

        public void Visit(PlaceholderSurrogate surrogate)
        {
            this.components.Add(surrogate.ToDomain());
        }
    }
}