namespace Kola.Domain.Instances
{
    using System.Collections.Generic;

    using Kola.Domain.Rendering;

    public class ContainerInstance : ComponentInstance
    {
        public ContainerInstance(IEnumerable<int> path, string name, IEnumerable<PropertyInstance> properties, IEnumerable<ComponentInstance> components = null)
            : base(path)
        {
            this.Name = name;
            this.Properties = properties;
            this.Components = components;
        }

        public string Name { get; private set; }

        public IEnumerable<PropertyInstance> Properties { get; private set; }

        public IEnumerable<ComponentInstance> Components { get; private set; }

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