namespace Kola.Persistence.Extensions
{
    using System.Collections.Generic;
    using System.Linq;

    using Kola.Domain;
    using Kola.Persistence.Surrogates;

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
                surrogate.Components.ToDomain(),
                surrogate.Amendments.ToDomain());
        }
    }
}