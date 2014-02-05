namespace Kola.Rendering
{
    using Kola.Domain.Instances;

    public class Processor : IProcessor
    {
        private readonly IHandlerFactory handlerFactory;

        public Processor(IHandlerFactory handlerFactory)
        {
            this.handlerFactory = handlerFactory;
        }

        public IResult Process(IComponentInstance component)
        {
            System.Diagnostics.Debug.WriteLine(string.Format("Processing component {0}", component.Name));
            return component.Render(new Renderer(this.handlerFactory, this));
        }
    }
}