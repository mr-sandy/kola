namespace Kola.Domain.Instances
{
    using System.Collections.Generic;

    using Kola.Domain.Rendering;

    public class ContainerInstance : IComponentInstance
    {
        public ContainerInstance(string name, IEnumerable<ParameterInstance> parameters, IEnumerable<IComponentInstance> components = null)
        {
            this.Name = name;
            this.Parameters = parameters;
            this.Components = components;
        }

        public string Name { get; private set; }

        public IEnumerable<ParameterInstance> Parameters { get; private set; }

        public IEnumerable<IComponentInstance> Components { get; private set; }

        public IResult Render(IRenderer renderer)
        {
            return renderer.Render(this);
        }
    }
}