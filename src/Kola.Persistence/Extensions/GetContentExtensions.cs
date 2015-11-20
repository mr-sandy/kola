namespace Kola.Persistence.Extensions
{
    using System.Collections.Generic;
    using System.Linq;

    using Kola.Domain.Composition;

    public static class ContentsExtensions
    {
        public static Template TakeTemplate(this IEnumerable<IContent> contents)
        {
            return contents?.OfType<Template>().FirstOrDefault();
        }

        public static Redirect TakeRedirect(this IEnumerable<IContent> contents)
        {
            return contents?.OfType<Redirect>().FirstOrDefault();
        }

        public static IContent TakeRedirectElseTemplate(this IEnumerable<IContent> contents)
        {
            if (contents == null) return null;
            return contents.TakeRedirect() ?? contents.TakeTemplate() as IContent;
        }
    }
}