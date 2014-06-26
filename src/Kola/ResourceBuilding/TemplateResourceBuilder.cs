namespace Kola.ResourceBuilding
{
    using System.Linq;

    using Kola.Domain.Composition;
    using Kola.Extensions;
    using Kola.Resources;

    internal class TemplateResourceBuilder
    {
        public TemplateResource Build(Template template)
        {
            var visitor = new ResourceBuildingComponentVisitor(template.Path);

            return new TemplateResource
            {
                Components = template.Components.Select((c, i) => c.Accept(visitor, new[] { i })),
                Links = new[]
                            {
                                new LinkResource
                                    {
                                        Rel = "self",
                                        Href = new[] { "_kola", "templates" }.Concat(template.Path).ToHttpPath()
                                    },
                                new LinkResource
                                    {
                                        Rel = "amendments",
                                        Href = new[] { "_kola", "templates" }.Concat(template.Path).Append("_amendments").ToHttpPath()
                                    }
                            }
            };
        }
    }
}