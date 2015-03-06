namespace Kola.Domain.Instances
{
    using System.Collections.Generic;
    using System.Linq;

    using Kola.Domain.Extensions;

    public class ComponentFindingComponentInstanceVisitor : IComponentInstanceVisitor<ComponentInstance, IEnumerable<int>>
    {
        public ComponentInstance Find(PageInstance page, IEnumerable<int> path)
        {
            if (!path.Any() || page.Components.Count() < path.First())
            {
                throw new KolaException("No component at specified path");
            }

            return page.Components.ElementAt(path.First()).Accept(this, path.Skip(1));
        }

        public ComponentInstance Visit(AtomInstance atom, IEnumerable<int> path)
        {
            if (path.Any())
            {
                throw new KolaException("No component at specified path");
            }

            return atom;
        }

        public ComponentInstance Visit(ContainerInstance container, IEnumerable<int> path)
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

        public ComponentInstance Visit(WidgetInstance widget, IEnumerable<int> path)
        {
            if (!path.Any())
            {
                return widget;
            }

            var finder = new AreaFindingComponentInstanceVisitor();

            var areaPath = widget.Path.Append(path.First());

            var area = finder.Find(widget, areaPath);

            if (area == null)
            {
                throw new KolaException("No component at specified path");
            }

            var remainder = path.Skip(1);

            if (!remainder.Any())
            {
                return area;
            }

            return area.Accept(this, remainder);
        }

        public ComponentInstance Visit(AreaInstance area, IEnumerable<int> path)
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

        public ComponentInstance Visit(PlaceholderInstance placeholder, IEnumerable<int> path)
        {
            if (path.Any())
            {
                throw new KolaException("No component at specified path");
            }

            return placeholder;
        }
    }

    internal class AreaFindingComponentInstanceVisitor : IComponentInstanceVisitor<AreaInstance, IEnumerable<int>>
    {
        public AreaInstance Find(WidgetInstance widget, IEnumerable<int> path)
        {
            if (!widget.Components.Any())
            {
                throw new KolaException("No component at specified path");
            }

            return widget.Components.Select(c => c.Accept(this, path)).FirstOrDefault(a => a != null);
        }

        public AreaInstance Visit(AtomInstance atom, IEnumerable<int> path)
        {
            return null;
        }

        public AreaInstance Visit(ContainerInstance container, IEnumerable<int> path)
        {
            return container.Components.Select(c => c.Accept(this, path)).FirstOrDefault(a => a != null);
        }

        public AreaInstance Visit(WidgetInstance widget, IEnumerable<int> path)
        {
            return widget.Components.Select(c => c.Accept(this, path)).FirstOrDefault(a => a != null);
        }

        public AreaInstance Visit(AreaInstance area, IEnumerable<int> path)
        {
            if (area.Path.IsEquivalentTo(path))
            {
                return area;
            }

            return area.Components.Select(c => c.Accept(this, path)).FirstOrDefault(a => a != null);
        }

        public AreaInstance Visit(PlaceholderInstance placeholder, IEnumerable<int> path)
        {
            return placeholder.Content.Accept(this, path);
        }
    }
}