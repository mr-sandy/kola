namespace Kola.Rendering.Caching
{
    using System;

    using Kola.Domain.Instances;
    using Kola.Rendering;

    public class CachingRenderer : IRenderer
    {
        private readonly IRenderer inner;
        private readonly ICacheManager cacheManager;

        public CachingRenderer(IRenderer inner, ICacheManager cacheManager)
        {
            this.inner = inner;
            this.cacheManager = cacheManager;
        }

        //public IResult Process(IComponentInstance component)
        //{
        //    return new CachingResult(this.inner.Process(component), this.cacheManager, component);
        //}

        public IResult Render(AtomInstance atom)
        {
            throw new NotImplementedException();
        }

        public IResult Render(ContainerInstance container)
        {
            throw new NotImplementedException();
        }

        public IResult Render(WidgetInstance widget)
        {
            throw new NotImplementedException();
        }

        public IResult Render(PlaceholderInstance placeholder)
        {
            throw new NotImplementedException();
        }
    }
}