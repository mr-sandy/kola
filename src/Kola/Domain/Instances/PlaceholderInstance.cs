namespace Kola.Domain.Instances
{
    using System.Collections.Generic;

    using Kola.Domain.Rendering;

    public class PlaceholderInstance : IComponentInstance
    {
        public PlaceholderInstance(IEnumerable<IComponentInstance> components)
        {
            this.Components = components;
        }

        public IEnumerable<IComponentInstance> Components { get; private set; }

        public IResult Render(IRenderer renderer)
        {
            return renderer.Render(this);
        }
    }
}