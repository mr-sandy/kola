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
            return component.RenderingInstructions.AnnotateComponentPaths
                ? new AnnotatedResult(this.inner.Render(component), component.Path)
                : this.inner.Render(component);
        }

        public IResult Render(ContainerInstance component)
        {
            return component.RenderingInstructions.AnnotateComponentPaths
                ? new AnnotatedResult(this.inner.Render(component), component.Path)
                : this.inner.Render(component);
        }

        public IResult Render(WidgetInstance component)
        {
            return component.RenderingInstructions.AnnotateComponentPaths
                ? new AnnotatedResult(this.inner.Render(component), component.Path)
                : this.inner.Render(component);
        }

        public IResult Render(AreaInstance component)
        {
            return component.RenderingInstructions.AnnotateComponentPaths
                ? new AnnotatedResult(this.inner.Render(component), component.Path)
                : this.inner.Render(component);
        }
    }
}