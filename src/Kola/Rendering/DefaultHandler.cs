namespace Kola.Rendering
{
    using Kola.Domain;
    using Kola.Domain.Instances;

    public class DefaultHandler : IHandler
    {
        public IResult Render(IComponentInstance component)
        {
            return new Result(h => h.RenderPartial(component.Name, component));
        }
    }
}