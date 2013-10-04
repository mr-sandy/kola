namespace Kola.Persistence.Surrogates.Extensions
{
    using System.Linq;

    using Kola.Domain;

    public static class TemplateExtensions
    {
        public static TemplateSurrogate ToSurrogate(this Template template)
        {
            return new TemplateSurrogate()
                {
                    Amendments = template.Amendments.ToSurrogate().ToArray(),
                    Components = template.Components.ToSurrogate().ToArray()
                };
        }

        public static Template ToDomain(this TemplateSurrogate surrogate)
        {
            return new Template()
            {
                Amendments = template.Amendments.ToSurrogate().ToArray(),
                Components = template.Components.ToSurrogate().ToArray()
            };
        }
    }
}