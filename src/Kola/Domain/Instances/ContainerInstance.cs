namespace Kola.Domain.Instances
{
    using System.Collections.Generic;

    using Kola.Domain.Rendering;

    public class ContainerInstance : ComponentInstance
    {
        public ContainerInstance(IEnumerable<int> path, string name, IEnumerable<ParameterInstance> parameters, IEnumerable<ComponentInstance> components = null)
            : base(path)
        {
            this.Name = name;
            this.Parameters = parameters;
            this.Components = components;
        }

        public string Name { get; private set; }

        public IEnumerable<ParameterInstance> Parameters { get; private set; }

        public IEnumerable<ComponentInstance> Components { get; private set; }

        public override IResult Render(IRenderer renderer)
        {
            return renderer.Render(this);
        }
    }
}