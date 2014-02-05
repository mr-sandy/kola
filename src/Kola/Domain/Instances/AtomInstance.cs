namespace Kola.Domain.Instances
{
    using System.Collections.Generic;

    using Kola.Rendering;

    public class AtomInstance : IComponentInstance
    {
        public AtomInstance(string name, IEnumerable<ParameterInstance> parameters)
        {
            this.Name = name;
            this.Parameters = parameters;
        }

        public string Name { get; private set; }

        public IEnumerable<ParameterInstance> Parameters { get; private set; }

        public IResult Render(IRenderer renderer)
        {
            return renderer.Render(this);
        }
    }
}