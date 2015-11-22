namespace Kola.Persistence.Extensions
{
    using System.Collections.Generic;
    using System.Linq;

    using Kola.Domain.Composition;

    public static class ContentWithContextExtensions
    {
        public static FindContentResult TakeTemplateResult(this IEnumerable<FindContentResult> contents)
        {
            return contents?.FirstOrDefault(c => c.Content is Template);
        }

        public static FindContentResult TakeRedirectResult(this IEnumerable<FindContentResult> contents)
        {
            return contents?.FirstOrDefault(c => c.Content is Redirect);
        }

        public static FindContentResult FavourRedirectResult(this IEnumerable<FindContentResult> contents)
        {
            if (contents == null)
            {
                return null;
            }

            var contentWithContexts = contents as FindContentResult[] ?? contents.ToArray();
            return contentWithContexts.TakeRedirectResult() ?? contentWithContexts.TakeTemplateResult();
        }
    }
}