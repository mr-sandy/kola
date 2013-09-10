namespace Kola.Nancy.Extensions
{
    using Kola.Domain;
    using Kola.Resources;

    internal static class TemplateExtensions
    {
        public static TemplateResource ToResource(this Template template)
        {
            return new TemplateResource
                {
                    Links = new[]
                            {
                                new LinkResource
                                    {
                                        Rel = "self", Href = string.Format("/{0}", string.Join("/", template.Path))
                                    }
                            }
                };
        }
    }
}