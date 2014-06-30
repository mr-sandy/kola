namespace Kola.Domain.Composition
{
    using System.Collections.Generic;
    using System.Linq;

    internal class ComponentFindingComponentVisitor : IComponentVisitor<IComponent, IEnumerable<int>>
    {
        public IComponent Find(Template template, IEnumerable<int> path)
        {
            if (path.Count() == 0)
            {
                throw new KolaException("No path specified");
            }

            if (template.Components.Count() < path.First())
            {
                throw new KolaException("No component at specified path");
            }

            return template.Components.ElementAt(path.First()).Accept(this, path.Skip(1));
        }

        public IComponent Visit(Atom atom, IEnumerable<int> path)
        {
            if (path.Count() > 0)
            {
                throw new KolaException("No component at specified path");
            }

            return atom;
        }

        public IComponent Visit(Container container, IEnumerable<int> path)
        {
            if (path.Count() == 0)
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
            if (path.Count() == 0)
            {
                return widget;
            }

            if (widget.Areas.Count() < path.First())
            {
                throw new KolaException("No component at specified path");
            }

            var area = widget.Areas.ElementAt(path.First());

            return this.VisitArea(area, path.Skip(1));
        }

        public IComponent Visit(Placeholder placeholder, IEnumerable<int> path)
        {
            if (path.Count() > 0)
            {
                throw new KolaException("No component at specified path");
            }

            return placeholder;
        }

        private IComponent VisitArea(Area area, IEnumerable<int> path)
        {
            if (path.Count() == 0)
            {
                throw new KolaException("No path specified");
            }

            if (area.Components.Count() < path.First())
            {
                throw new KolaException("No component at specified path");
            }

            return area.Components.ElementAt(path.First()).Accept(this, path.Skip(1));
        }
    }
}