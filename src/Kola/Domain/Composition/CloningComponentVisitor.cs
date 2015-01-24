namespace Kola.Domain.Composition
{
    using System;

    public class CloningComponentVisitor : IComponentVisitor<IComponent>
    {
        public IComponent Visit(Atom atom)
        {
            throw new NotImplementedException();
        }

        public IComponent Visit(Container container)
        {
            throw new NotImplementedException();
        }

        public IComponent Visit(Widget widget)
        {
            throw new NotImplementedException();
        }

        public IComponent Visit(Placeholder placeholder)
        {
            throw new NotImplementedException();
        }

        public IComponent Visit(Area area)
        {
            throw new NotImplementedException();
        }
    }
}