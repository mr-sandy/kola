namespace Kola.Domain.Composition
{
    using System.Collections.Generic;
    using System.Linq;

    internal class CollectionFindingComponentVisitor : IComponentVisitor<IComponentCollection, IEnumerable<int>>
    {
        public IComponentCollection Find(Template template, IEnumerable<int> path)
        {
            if (!path.Any())
            {
                return template;
            }

            if (template.Components.Count() < path.First())
            {
                throw new KolaException("No collection at specified path");
            }

            return template.Components.ElementAt(path.First()).Accept(this, path.Skip(1));
        }

        public IComponentCollection Visit(Atom atom, IEnumerable<int> path)
        {
            throw new KolaException("No collection at specified path");
        }

        public IComponentCollection Visit(Container container, IEnumerable<int> path)
        {
            if (!path.Any())
            {
                return container;
            }

            if (container.Components.Count() < path.First())
            {
                throw new KolaException("No collection at specified path");
            }

            return container.Components.ElementAt(path.First()).Accept(this, path.Skip(1));
        }

        public IComponentCollection Visit(Widget widget, IEnumerable<int> path)
        {
            if (!path.Any())
            {
                throw new KolaException("No collection at specified path");
            }

            if (widget.Areas.Count() < path.First())
            {
                throw new KolaException("No collection at specified path");
            }

            return widget.Areas.ElementAt(path.First()).Accept(this, path.Skip(1));
        }

        public IComponentCollection Visit(Placeholder placeholder, IEnumerable<int> path)
        {
                throw new KolaException("No collection at specified path");
        }

        public IComponentCollection Visit(Area area, IEnumerable<int> path)
        {
            if (!path.Any())
            {
                return area;
            }

            if (area.Components.Count() < path.First())
            {
                throw new KolaException("No collection at specified path");
            }

            return area.Components.ElementAt(path.First()).Accept(this, path.Skip(1));
        }
    }
}