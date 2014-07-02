namespace Kola.Domain.Rendering
{
    using System.Collections.Generic;

    using Kola.Domain.Instances;
    using Kola.Extensions;

    public class PathAnnotatingRenderer : IRenderer
    {
        private readonly IRenderer inner;

        public PathAnnotatingRenderer(IRenderer inner)
        {
            this.inner = inner;
        }

        public IResult Render(PageInstance component)
        {
            return this.inner.Render(component);
        }

        public IResult Render(IEnumerable<ComponentInstance> component)
        {
            return this.inner.Render(component);
        }

        public IResult Render(AtomInstance component)
        {
            return new AnnotatedResult(this.inner.Render(component), component.Path);
        }

        public IResult Render(ContainerInstance component)
        {
            return new AnnotatedResult(this.inner.Render(component), component.Path);
        }

        public IResult Render(WidgetInstance component)
        {
            return new AnnotatedResult(this.inner.Render(component), component.Path);
        }

        public IResult Render(AreaInstance component)
        {
            return new AnnotatedResult(this.inner.Render(component), component.Path);
        }
    }
}