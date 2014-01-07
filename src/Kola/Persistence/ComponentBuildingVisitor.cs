namespace Kola.Persistence
{
    using System.Collections.Generic;

    using Kola.Editing;
    using Kola.Persistence.Extensions;
    using Kola.Persistence.Surrogates;

    public class ComponentBuildingVisitor : IComponentSurrogateVisitor
    {
        private readonly List<Component> components = new List<Component>();

        public IEnumerable<Component> Components
        {
            get { return this.components; }
        }

        public void Visit(CompositeComponentSurrogate surrogate)
        {
            this.components.Add(surrogate.ToDomain());
        }

        public void Visit(SimpleComponentSurrogate surrogate)
        {
            this.components.Add(surrogate.ToDomain());
        }
    }
}