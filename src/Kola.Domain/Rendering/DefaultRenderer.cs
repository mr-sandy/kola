namespace Kola.Domain.Rendering
{
    using Kola.Domain.Composition;
    using Kola.Domain.Instances;
    using Kola.Domain.Specifications;

    public class DefaultRenderer : IRenderer<AtomInstance>, IRenderer<ContainerInstance>
    {
        private readonly IPluginComponentSpecification<IComponentWithProperties> specification;

        public DefaultRenderer(IPluginComponentSpecification<IComponentWithProperties> specification)
        {
            this.specification = specification;
        }

        public IResult Render(AtomInstance atom)
        {
            return new Result(h => h.RenderPartial(this.specification.ViewName, atom));
        }

        public IResult Render(ContainerInstance container)
        {
            return new Result(h => h.RenderPartial(this.specification.ViewName, container));
        }
    }
}