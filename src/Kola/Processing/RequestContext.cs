namespace Kola.Processing
{
    public class RequestContext
    {
        public RequestContext(IHandlerFactory handlerFactory, IViewHelper viewHelper)
        {
            this.HandlerFactory = handlerFactory;
            ViewHelper = viewHelper;
        }

        public IHandlerFactory HandlerFactory { get; private set; }
        
        public IViewHelper ViewHelper { get; private set; }
    }
}