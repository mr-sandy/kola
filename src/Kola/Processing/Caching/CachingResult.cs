namespace Kola.Processing.Caching
{
    using Kola.Processing;

    public class CachingResult : IResult
    {
        private readonly IResult inner;
        private readonly ICacheManager cacheManager;
        private readonly IComponent component;

        public CachingResult(IResult inner, ICacheManager cacheManager, IComponent component)
        {
            this.inner = inner;
            this.cacheManager = cacheManager;
            this.component = component;
        }

        public string ToHtml(IViewHelper viewHelper)
        {
            var result = this.inner.ToHtml(viewHelper);

            this.cacheManager.Record(this.component, result);

            return result;
        }
    }
}