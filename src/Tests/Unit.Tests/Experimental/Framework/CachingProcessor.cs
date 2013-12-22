namespace Unit.Tests.Experimental.Framework
{
    public class CachingProcessor : IProcessor
    {
        private readonly IProcessor inner;
        private readonly ICacheManager cacheManager;

        public CachingProcessor(IProcessor inner, ICacheManager cacheManager)
        {
            this.inner = inner;
            this.cacheManager = cacheManager;
        }

        public IResult Process(IComponent component)
        {
            return new CachingResult(this.inner.Process(component), this.cacheManager, component);
        }
    }

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

    public interface ICacheManager
    {
        void Record(IComponent component, string value);
    }
}