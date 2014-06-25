namespace Kola.Persistence.Extensions
{
    using System.Collections.Generic;

    using Kola.Domain.Composition;
    using Kola.Persistence.SurrogateBuilders;
    using Kola.Persistence.Surrogates;

    public static class TemplateExtensions
    {
        public static TemplateSurrogate ToSurrogate(this Template template)
        {
            return new TemplateSurrogateBuilder().Build(template);
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