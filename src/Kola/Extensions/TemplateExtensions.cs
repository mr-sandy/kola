namespace Kola.Extensions
{
    using Kola.Domain;
    using Kola.Resources;

    internal static class TemplateExtensions
    {
        public static TemplateResource ToResource(this Template template)
        {
            return new TemplateResource
                {
                    Components = template.Components.ToResource(template.Path),
                    Amendments = template.Amendments.ToResource(template.Path),
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