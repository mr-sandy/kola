namespace Kola.Domain.Rendering
{
    using Kola.Domain.Instances;

    public class DefaultHandler : IHandler<AtomInstance>, IHandler<ContainerInstance>
    {
        public IResult Render(AtomInstance atom)
        {
            return new Result(h => h.RenderPartial(atom.Name, atom));
        }

        public IResult Render(ContainerInstance container)
        {
            return new Result(h => h.RenderPartial(container.Name, container));
        }
    }
}