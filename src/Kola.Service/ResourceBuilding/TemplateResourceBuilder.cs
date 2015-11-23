namespace Kola.Service.ResourceBuilding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Kola.Domain.Composition;
    using Kola.Resources;
    using Kola.Service.Extensions;

    public class TemplateResourceBuilder : IResourceBuilder<Template>
    {
        private readonly PathInstanceBuilder pathInstanceBuilder;

        public TemplateResourceBuilder(PathInstanceBuilder pathInstanceBuilder)
        {
            this.pathInstanceBuilder = pathInstanceBuilder;
        }

        public object Build(Template template)
        {
            var visitor = new ResourceBuildingComponentVisitor(template.Path);

            return new TemplateResource
            {
                Components = template.Components.Select((c, i) => c.Accept(visitor, new[] { i })),
                Links = this.GetLinks(template).ToArray()
            };
        }

        public string Location(Template widgetSpecification)
        {
            return new[] { "_kola", "templates" }.Concat(widgetSpecification.Path).ToHttpPath();
        }

        private IEnumerable<LinkResource> GetLinks(Template template)
        {
            yield return new LinkResource
            {
                Rel = "self",
                Href = new[] { "_kola", "templates" }.Concat(template.Path).ToHttpPath()
            };

            yield return new LinkResource
            {
                Rel = "amendments",
                Href = new[] { "_kola", "templates" }.Concat(template.Path).Append("_amendments").ToHttpPath()
            };

            foreach (var previewUrl in this.pathInstanceBuilder.Build(template.Path))
            {
                yield return new LinkResource {
                    Rel = "preview",
                    Href = previewUrl
                };
            }
        }
   }
}