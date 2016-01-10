namespace Kola.Domain.Composition
{
    using System.Collections.Generic;
    using System.Linq;

    // TODO {SC} Can this and the CollectionFindingComponentVisitor be unified now that Areas are IComponents?
    internal class ComponentFindingComponentVisitor : IComponentVisitor<IComponent, IEnumerable<int>>
    {
        public IComponent Find(IComponentCollection componentCollection, IEnumerable<int> path)
        {
            if (!path.Any())
            {
                throw new KolaException("No path specified");
            }

            if (componentCollection.Components.Count() < path.First())
            {
                throw new KolaException("No component at specified path");
            }

            return componentCollection.Components.ElementAt(path.First()).Accept(this, path.Skip(1));
        }

        public IComponent Visit(Atom atom, IEnumerable<int> path)
        {
            if (path.Any())
            {
                throw new KolaException("No component at specified path");
            }

            return atom;
        }

        public IComponent Visit(Container container, IEnumerable<int> path)
        {
            if (!path.Any())
            {
                return container;
            }

            if (container.Components.Count() < path.First())
            {
                throw new KolaException("No component at specified path");
            }

            return container.Components.ElementAt(path.First()).Accept(this, path.Skip(1));
        }

        public IComponent Visit(Widget widget, IEnumerable<int> path)
        {
            if (!path.Any())
            {
                return widget;
            }

            if (widget.Areas.Count() < path.First())
            {
                throw new KolaException("No component at specified path");
            }

            return widget.Areas.ElementAt(path.First()).Accept(this, path.Skip(1));
        }

        public IComponent Visit(Placeholder placeholder, IEnumerable<int> path)
        {
            if (path.Any())
            {
                throw new KolaException("No component at specified path");
            }

            return placeholder;
        }

        public IComponent Visit(Area area, IEnumerable<int> path)
        {
            if (!path.Any())
            {
                return area;
            }

            if (area.Components.Count() < path.First())
            {
                throw new KolaException("No component at specified path");
            }

            return area.Components.ElementAt(path.First()).Accept(this, path.Skip(1));
        }
    }
}