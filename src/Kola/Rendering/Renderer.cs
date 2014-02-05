namespace Kola.Rendering
{
    using System.Linq;

    using Kola.Domain.Instances;

    public class Renderer : IRenderer
    {
        private readonly IHandlerFactory handlerFactory;

        private readonly IProcessor processor;

        public Renderer(IHandlerFactory handlerFactory, IProcessor processor)
        {
            this.handlerFactory = handlerFactory;
            this.processor = processor;
        }

        public IResult Render(AtomInstance atom)
        {
            return this.handlerFactory.GetAtomHandler(atom.Name).Render(atom);
        }

        public IResult Render(ContainerInstance container)
        {
            return this.handlerFactory.GetContainerHandler(container.Name).Render(container);
        }

        public IResult Render(WidgetInstance widget)
        {
            return new CompositeResult(widget.Components.Select(c => this.processor.Process(c)));
        }

        public IResult Render(PlaceholderInstance placeholder)
        {
            return new CompositeResult(placeholder.Components.Select(c => this.processor.Process(c)));
        }
    }
}