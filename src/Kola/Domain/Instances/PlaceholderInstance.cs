namespace Kola.Domain.Instances
{
    using System.Collections.Generic;

    using Kola.Rendering;

    public class PlaceholderInstance : IComponentInstance
    {
        public PlaceholderInstance(IEnumerable<IComponentInstance> components)
        {
            this.Components = components;
        }

        public IEnumerable<IComponentInstance> Components { get; private set; }

        public string Name
        {
            get { return string.Empty; } 
        }

        public IResult Render(IRenderer renderer)
        {
            return renderer.Render(this);
        }
    }
}