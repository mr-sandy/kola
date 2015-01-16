namespace Kola.ResourceBuilding
{
    using System.Collections.Generic;
    using System.Linq;

    using Kola.Domain.Composition;
    using Kola.Extensions;
    using Kola.Resources;

    internal class ResourceBuildingComponentVisitor : IComponentVisitor<ComponentResource, IEnumerable<int>>
    {
        private readonly IEnumerable<string> templatePath;
        private readonly ResourceBuildingPropertyValueVisitor propertyValueBuilder = new ResourceBuildingPropertyValueVisitor();

        public ResourceBuildingComponentVisitor(IEnumerable<string> templatePath)
        {
            this.templatePath = templatePath;
        }

        public ComponentResource Visit(Atom atom, IEnumerable<int> context)
        {
            return new AtomResource
                {
                    Name = atom.Name,
                    Path = context.Select(i => i.ToString()).ToHttpPath(),
                    Properties = this.BuildProperties(atom.Properties),
                    Links = this.BuildLinks(context)
                };
        }

        public ComponentResource Visit(Container container, IEnumerable<int> context)
        {
            return new ContainerResource
                {
                    Name = container.Name,
                    Path = context.Select(i => i.ToString()).ToHttpPath(),
                    Components = container.Components.Select((c, i) => c.Accept(this, context.Append(i))),
                    Properties = this.BuildProperties(container.Properties),
                    Links = this.BuildLinks(context)
                };
        }

        public ComponentResource Visit(Widget widget, IEnumerable<int> context)
        {
            return new WidgetResource
                {
                    Name = widget.Name,
                    Areas = widget.Areas.Select((c, i) => c.Accept(this, context.Append(i))),
                    Path = context.Select(i => i.ToString()).ToHttpPath(),
                    Properties = this.BuildProperties(widget.Properties),
                    Links = this.BuildLinks(context)
                };
        }

        public ComponentResource Visit(Placeholder placeholder, IEnumerable<int> context)
        {
            return new PlaceholderResource
                {
                    Path = context.Select(i => i.ToString()).ToHttpPath(),
                    Links = this.BuildLinks(context)
                };
        }

        public ComponentResource Visit(Area area, IEnumerable<int> context)
        {
            return new AreaResource
            {
                Name = area.Name,
                Path = context.Select(i => i.ToString()).ToHttpPath(),
                Components = area.Components.Select((c, i) => c.Accept(this, context.Append(i))),
                Links = this.BuildLinks(context)
            };
        }

        private IEnumerable<PropertyResource> BuildProperties(IEnumerable<Property> properties)
        {
            return properties.Select(property => new PropertyResource
                {
                    Name = property.Name,
                    Type = property.Type,
                    Value = property.Value == null ? null : property.Value.Accept(this.propertyValueBuilder),
                    Links = new[]
                        {
                            new LinkResource { Rel = "type", Href = "/_kola/property-types/" + property.Type.Urlify() }
                        }
                });
        }

        private IEnumerable<LinkResource> BuildLinks(IEnumerable<int> context)
        {
            yield return new LinkResource
                {
                    Rel = "self",
                    Href = new[] { "_kola", "templates" }.Concat(this.templatePath).Append("_components").Concat(context.Select(i => i.ToString())).ToHttpPath()
                };

            yield return new LinkResource
            {
                Rel = "preview",
                Href = string.Format("{0}?componentPath={1}", new[] { "_kola", "preview" }.Concat(this.templatePath).ToHttpPath(), context.Select(i => i.ToString()).ToHttpPath())
            };
        }
    }
}