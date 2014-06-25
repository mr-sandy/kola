namespace Kola.ResourceBuilders
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
                                        Href = template.Path.ToHttpPath()
                                    },
                                new LinkResource
                                    {
                                        Rel = "amendments", 
                                        Href = template.Path.Append("_amendments").ToHttpPath() 
                                    }
                            }
            };
        }
    }
}