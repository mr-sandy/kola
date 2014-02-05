namespace Kola.Domain.Instances
{
    using System.Collections.Generic;

    using Kola.Domain.Rendering;

    public class WidgetInstance : IComponentInstance
    {
        public WidgetInstance(IEnumerable<IComponentInstance> components = null)
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