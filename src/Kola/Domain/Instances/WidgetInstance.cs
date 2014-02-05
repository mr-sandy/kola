namespace Kola.Domain.Instances
{
    using System.Collections.Generic;
    using System.Linq;

    using Kola.Rendering;

    public class WidgetInstance : IComponentInstance
    {
        public WidgetInstance(string name, IEnumerable<IComponentInstance> components = null)
        {
            this.Name = name;
            this.Components = components;
        }

        public string Name { get; private set; }

        public IEnumerable<IComponentInstance> Components { get; private set; }

        public IResult Render(IHandlerFactory handlerFactory)
        {
            return new CompositeResult(this.Components.Select(c => c.Render(handlerFactory)));
        }
    }
}