namespace Kola.Service.ResourceBuilding
{
    using System.Collections.Generic;
    using System.Linq;

    using Kola.Domain.Composition;
    using Kola.Resources;
    using Kola.Service.Extensions;

    internal class ResourceBuildingComponentVisitor : IComponentVisitor<ComponentResource, IEnumerable<int>>
    {
        private readonly AmendableComponentCollection owner;
        private readonly ResourceBuildingPropertyValueVisitor propertyValueBuilder = new ResourceBuildingPropertyValueVisitor();

        public ResourceBuildingComponentVisitor(AmendableComponentCollection owner)
        {
            this.owner = owner;
        }

        public ComponentResource Visit(Atom atom, IEnumerable<int> context)
        {
            var contextArray = context as int[] ?? context.ToArray();

            return new AtomResource
            {
                Name = atom.Name,
                Path = contextArray.Select(i => i.ToString()).ToHttpPath(),
                Properties = this.BuildProperties(atom.Properties),
                Comment = atom.Comment,
                Links = this.BuildLinks(contextArray)
            };
        }

        public ComponentResource Visit(Container container, IEnumerable<int> context)
        {
            var contextArray = context as int[] ?? context.ToArray();

            return new ContainerResource
            {
                Name = container.Name,
                Path = contextArray.Select(i => i.ToString()).ToHttpPath(),
                Components = container.Components.Select((c, i) => c.Accept(this, contextArray.Append(i))),
                Properties = this.BuildProperties(container.Properties),
                Comment = container.Comment,
                Links = this.BuildLinks(contextArray)
            };
        }

        public ComponentResource Visit(Widget widget, IEnumerable<int> context)
        {
            var contextArray = context as int[] ?? context.ToArray();

            return new WidgetResource
            {
                Name = widget.Name,
                Areas = widget.Areas.Select((c, i) => c.Accept(this, contextArray.Append(i))),
                Path = contextArray.Select(i => i.ToString()).ToHttpPath(),
                Properties = this.BuildProperties(widget.Properties),
                Comment = widget.Comment,
                Links = this.BuildLinks(contextArray)
            };
        }

        public ComponentResource Visit(Placeholder placeholder, IEnumerable<int> context)
        {
            var contextArray = context as int[] ?? context.ToArray();

            return new PlaceholderResource
            {
                Path = contextArray.Select(i => i.ToString()).ToHttpPath(),
                Links = this.BuildLinks(contextArray)
            };
        }

        public ComponentResource Visit(Area area, IEnumerable<int> context)
        {
            var contextArray = context as int[] ?? context.ToArray();

            return new AreaResource
            {
                Name = area.Name,
                Path = contextArray.Select(i => i.ToString()).ToHttpPath(),
                Components = area.Components.Select((c, i) => c.Accept(this, contextArray.Append(i))),
                Links = this.BuildLinks(contextArray)
            };
        }

        private IEnumerable<PropertyResource> BuildProperties(IEnumerable<Property> properties)
        {
            return properties.Select(property => new PropertyResource
            {
                Name = property.Name,
                Type = property.Type,
                Value = property.Value?.Accept(this.propertyValueBuilder),
                Links = new[]
                        {
                            new LinkResource { Rel = "type", Href = "/_kola/property-types/" + property.Type.Urlify() }
                        }
            }).OrderBy(p => p.Name);
        }

        private IEnumerable<LinkResource> BuildLinks(int[] context)
        {
            var componentsPath = this.owner.Accept(new PathBuildingOwnerVisitor("components"));
            var previewPath = this.owner.Accept(new PreviewPathBuildingOwnerVisitor());

            yield return new LinkResource
            {
                Rel = "self",
                Href = $"{componentsPath}&componentPath={context.Select(i => i.ToString()).ToHttpPath()}"
            };

            yield return new LinkResource
            {
                Rel = "preview",
                Href = $"{previewPath}?componentPath={context.Select(i => i.ToString()).ToHttpPath()}"
            };
        }
    }
}