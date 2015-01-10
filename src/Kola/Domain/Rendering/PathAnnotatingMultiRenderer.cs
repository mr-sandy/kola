namespace Kola.Domain.Rendering
{
    using System.Collections.Generic;

    using Kola.Domain.Instances;

    public class PathAnnotatingMultiRenderer : IMultiRenderer
    {
        private readonly IMultiRenderer inner;

        public PathAnnotatingMultiRenderer(IMultiRenderer inner)
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
            //TODO {SC} add a 'outer renderer' property to delegate rendering upwards (if a parent exists)
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