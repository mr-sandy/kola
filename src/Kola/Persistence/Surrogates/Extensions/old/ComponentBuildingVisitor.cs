namespace Kola.Persistence.Surrogates.Extensions
{
    using System;
    using System.Collections.Generic;

    using Kola.Domain;

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