namespace Kola.Rendering
{
    using Kola.Domain.Instances;

    public class DefaultHandler : IHandler<AtomInstance>, IHandler<ContainerInstance>
    {
        public IResult Render(AtomInstance component)
        {
            return new Result(h => h.RenderPartial(component.Name, component));
        }

        public IResult Render(ContainerInstance component)
        {
            return new Result(h => h.RenderPartial(component.Name, component));
        }
    }
}