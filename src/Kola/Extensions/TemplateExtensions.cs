namespace Kola.Extensions
{
    using Kola.Domain.Composition;
    using Kola.ResourceBuilders;
    using Kola.Resources;

    internal static class TemplateExtensions
    {
        public static TemplateResource ToResource(this Template template)
        {
            return new TemplateResourceBuilder().Build(template);
        }
    }
}