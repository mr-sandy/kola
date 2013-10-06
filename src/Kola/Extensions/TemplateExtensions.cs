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
                    Components = template.Components.ToResource(),
                    Links = new[]
                            {
                                new LinkResource
                                    {
                                        Rel = "self", 
                                        Href = template.Path.ToHttpPath()
                                    }
                            }
                };
        }
    }
}