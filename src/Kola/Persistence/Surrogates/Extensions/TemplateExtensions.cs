namespace Kola.Persistence.Surrogates.Extensions
{
    using System.Collections.Generic;
    using System.Linq;

    using Kola.Domain;

    public static class TemplateExtensions
    {
        public static TemplateSurrogate ToSurrogate(this Template template)
        {
            return new TemplateSurrogate
                {
                    Amendments = template.Amendments.ToSurrogate().ToArray(),
                    Components = template.Components.ToSurrogate().ToArray()
                };
        }

        public static Template ToDomain(this TemplateSurrogate surrogate, IEnumerable<string> path)
        {
            return new Template(
                path, 
                surrogate.Amendments.ToDomain(),
                surrogate.Components.ToDomain());
        }
    }
}