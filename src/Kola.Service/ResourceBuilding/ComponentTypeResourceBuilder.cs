namespace Kola.Service.ResourceBuilding
{
    using System.Collections.Generic;
    using System.Linq;

    using Kola.Domain.Composition;
    using Kola.Domain.Specifications;
    using Kola.Resources;
    using Kola.Service.Extensions;

    public class ComponentTypeResourceBuilder
    {
        private readonly ComponentNamingSpecificationVisitor namingVisitor = new ComponentNamingSpecificationVisitor();

        public ComponentTypeResource Build(IComponentSpecification<IComponentWithProperties> component)
        {
            return new ComponentTypeResource
                {
                    Name = component.Name,
                    Type = component.Accept(this.namingVisitor),
                    Links = new[]
                        {
                            new LinkResource { Rel = "self", Href = "/_kola/component-types/" + component.Name.Urlify() }
                        }
                };
        }

        public IEnumerable<ComponentTypeResource> Build(IEnumerable<IComponentSpecification<IComponentWithProperties>> components)
        {
            return components.Select(this.Build);
        }
    }

    public class WidgetSpecificationResourceBuilder : IResourceBuilder<WidgetSpecification>
    {
        public object Build(WidgetSpecification widgetSpecification)
        {
            return new ComponentTypeResourceBuilder().Build(widgetSpecification);
        }

        public string Location(WidgetSpecification widgetSpecification)
        {
            return $"/_kola/widgets/{widgetSpecification.Name}";
        }
    }
}