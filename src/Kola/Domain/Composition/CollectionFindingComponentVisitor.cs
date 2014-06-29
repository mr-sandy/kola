namespace Kola.Domain.Composition
{
    using System;
    using System.Collections.Generic;

    internal class CollectionFindingComponentVisitor : IComponentVisitor<IComponent, IEnumerable<int>>
    {
        public IComponent Visit(Atom atom, IEnumerable<int> context)
        {
            throw new NotImplementedException();
        }

        public IComponent Visit(Container container, IEnumerable<int> context)
        {
            throw new NotImplementedException();
        }

        public IComponent Visit(Widget widget, IEnumerable<int> context)
        {
            throw new NotImplementedException();
        }

        public IComponent Visit(Placeholder placeholder, IEnumerable<int> context)
        {
            throw new NotImplementedException();
        }
    }
}