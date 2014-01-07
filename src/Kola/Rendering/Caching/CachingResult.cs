namespace Kola.Rendering.Caching
{
    using Kola.Rendering;

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