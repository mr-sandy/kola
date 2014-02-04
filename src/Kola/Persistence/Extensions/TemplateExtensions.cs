namespace Kola.Persistence.Extensions
{
    using System.Collections.Generic;
    using System.Linq;

    using Kola.Domain;
    using Kola.Domain.Templates;
    using Kola.Persistence.Surrogates;

    public static class TemplateExtensions
    {
        public static TemplateSurrogate ToSurrogate(this PageTemplate template)
        {
            return new TemplateSurrogate
                {
                    Amendments = template.Amendments.ToSurrogate().ToArray(),
                    Components = template.Components.ToSurrogate().ToArray()
                };
        }

        public static PageTemplate ToDomain(this TemplateSurrogate surrogate, IEnumerable<string> path)
        {
            return new PageTemplate(
                path, 
                surrogate.Components.ToDomain(),
                surrogate.Amendments.ToDomain());
        }
    }
}