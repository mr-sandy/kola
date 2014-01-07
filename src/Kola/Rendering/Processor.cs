namespace Kola.Rendering
{
    public class Processor : IProcessor
    {
        private readonly IHandlerFactory handlerFactory;

        public Processor(IHandlerFactory handlerFactory)
        {
            this.handlerFactory = handlerFactory;
        }

        public IResult Process(IComponent component)
        {
            var handler = this.handlerFactory.Create(component.Name);
            return handler.HandleRequest(component);
        }
    }
}