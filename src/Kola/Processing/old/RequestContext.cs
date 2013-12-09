namespace Kola.Processing
{
    public class RequestContext
    {
        public RequestContext(IHandlerFactory handlerFactory)
        {
            this.HandlerFactory = handlerFactory;
        }

        public IHandlerFactory HandlerFactory { get; private set; }
    }
}