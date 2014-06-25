namespace Kola.ResourceBuilders
{
    using System.Collections.Generic;
    using System.Linq;

    using Kola.Domain.Composition;
    using Kola.Extensions;
    using Kola.Resources;

    internal class ResourceBuildingComponentVisitor : IComponentVisitor<ComponentResource, IEnumerable<int>>
    {
        private readonly IEnumerable<string> templatePath;

        public ResourceBuildingComponentVisitor(IEnumerable<string> templatePath)
        {
            this.templatePath = templatePath;
        }

        public ComponentResource Visit(Atom atom, IEnumerable<int> context)
        {
            return new AtomResource
                {
                    Name = atom.Name,
                    Path = context,
                    Links = this.BuildLinks(context)
                };
        }

        public ComponentResource Visit(Container container, IEnumerable<int> context)
        {
            return new ContainerResource
                {
                    Name = container.Name,
                    Path = context,
                    Components = container.Components.Select((c, i) => c.Accept(this, context.Append(i))),
                    Links = this.BuildLinks(context)
                };
        }

        public ComponentResource Visit(Widget widget, IEnumerable<int> context)
        {
            var areas = widget.Areas.Select((area, i) =>
                {
                    var areaContext = context.Append(i);

                    return new AreaResource
                        {
                            Components = area.Components.Select((c, j) => c.Accept(this, areaContext.Append(j)))
                        };
                });

            return new WidgetResource
                {
                    Name = widget.Name,
                    Areas = areas,
                    Path = context,
                    Links = this.BuildLinks(context)
                };
        }

        public ComponentResource Visit(Placeholder placeholder, IEnumerable<int> context)
        {
            return new PlaceholderResource
                {
                    Path = context,
                    Links = this.BuildLinks(context)
                };
        }

        private IEnumerable<LinkResource> BuildLinks(IEnumerable<int> context)
        {
            yield return new LinkResource
                {
                    Rel = "self", 
                    Href = this.templatePath.Append("_components").Concat(context.Select(i => i.ToString())).ToHttpPath()
                };
        }
    }
}