namespace Kola.Rendering
{
    using System.Collections.Generic;
    using System.Linq;

    using Kola.Domain.Instances;

    public class KolaEngine : IKolaEngine
    {
        private readonly IRenderer renderer;

        public KolaEngine(IRenderer renderer)
        {
            this.renderer = renderer;
        }

        public IResult Render(PageInstance page)
        {
            return new CompositeResult(page.Components.Select(c => c.Render(this.renderer)));
        }

        public IResult Render(IEnumerable<IComponentInstance> components)
        {
            return new CompositeResult(components.Select(c => c.Render(this.renderer)));
        }
    }
}