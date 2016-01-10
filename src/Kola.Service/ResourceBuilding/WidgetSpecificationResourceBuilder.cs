namespace Kola.Service.ResourceBuilding
{
    using System.Collections.Generic;
    using System.Linq;

    using Kola.Domain.Specifications;
    using Kola.Resources;

    public class WidgetSpecificationResourceBuilder : IResourceBuilder<WidgetSpecification>
    {
        public object Build(WidgetSpecification widgetSpecification)
        {
            var visitor = new ResourceBuildingComponentVisitor(widgetSpecification);

            return new WidgetSpecificationResource
            {
                Components = widgetSpecification.Components.Select((c, i) => c.Accept(visitor, new[] { i })),
                Links = this.GetLinks(widgetSpecification).ToArray()
            };
        }

        public string Location(WidgetSpecification widgetSpecification)
        {
            return $"/_kola/widgets?name={widgetSpecification.Name}";
        }

        private IEnumerable<LinkResource> GetLinks(WidgetSpecification widgetSpecification)
        {
            yield return new LinkResource
            {
                Rel = "self",
                Href = this.Location(widgetSpecification)
            };

            yield return new LinkResource
            {
                Rel = "amendments",
                Href = $"/_kola/widgets/amendments?name={widgetSpecification.Name}"
            };

            //foreach (var previewUrl in this.pathInstanceBuilder.Build(widgetSpecification.Path))
            //{
            //    yield return new LinkResource
            //    {
            //        Rel = "preview",
            //        Href = previewUrl
            //    };
            //}
        }
    }
}