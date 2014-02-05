namespace Kola.Rendering.Caching
{
    using Kola.Domain.Instances;
    using Kola.Rendering;

    public class CachingProcessor : IProcessor
    {
        private readonly IProcessor inner;
        private readonly ICacheManager cacheManager;

        public CachingProcessor(IProcessor inner, ICacheManager cacheManager)
        {
            this.inner = inner;
            this.cacheManager = cacheManager;
        }

        public IResult Process(IComponentInstance component)
        {
            return new CachingResult(this.inner.Process(component), this.cacheManager, component);
        }
    }
}