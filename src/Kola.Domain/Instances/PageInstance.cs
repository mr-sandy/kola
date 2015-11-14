namespace Kola.Domain.Instances
{
    using System.Collections.Generic;

    using Kola.Domain.Rendering;

    public class PageInstance
    {
        public PageInstance(IEnumerable<ComponentInstance> components, IRenderingInstructions renderingInstructions)
        {
            this.Components = components;
            this.RenderingInstructions = renderingInstructions;
        }

        public IRenderingInstructions RenderingInstructions { get; private set; }

        public IEnumerable<ComponentInstance> Components { get; private set; }
    }
}