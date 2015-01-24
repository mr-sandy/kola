namespace Kola.Domain.Instances
{
    using System.Collections.Generic;

    using Kola.Domain.Rendering;

    public class AtomInstance : ComponentInstance
    {
        public AtomInstance(IEnumerable<int> path, IRenderingInstructions renderingInstructions, string name, IEnumerable<PropertyInstance> properties)
            : base(path, renderingInstructions)
        {
            this.Name = name;
            this.Properties = properties;
        }

        public string Name { get; private set; }

        public IEnumerable<PropertyInstance> Properties { get; private set; }

        public override T Accept<T, TContext>(IComponentInstanceVisitor<T, TContext> visitor, TContext context)
        {
            return visitor.Visit(this, context);
        }

        public override IResult Render(IMultiRenderer renderer)
        {
            return renderer.Render(this);
        }
    }
}