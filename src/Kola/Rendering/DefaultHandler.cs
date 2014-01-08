namespace Kola.Rendering
{
    using Kola.Domain;

    public class DefaultHandler : IHandler
    {
        public IResult HandleRequest(IComponentInstance component)
        {
            return new Result(h => h.RenderPartial(component.Name, component));
        }
    }
}