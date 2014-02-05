namespace Kola.Domain.Instances
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

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

        public IResult Render(IHandlerFactory handlerFactory)
        {
            return new CompositeResult(this.Components.Select(c => c.Render(handlerFactory)));
        }
    }
}