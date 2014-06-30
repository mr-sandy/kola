namespace Kola.Domain.Instances
{
    using System;
    using System.Collections.Generic;

    using Kola.Domain.Rendering;

    public class AreaInstance : IComponentInstance
    {
         public AreaInstance(IEnumerable<IComponentInstance> components = null)
        {
            this.Components = components;
        }

        public IEnumerable<IComponentInstance> Components { get; private set; }

        public IResult Render(IRenderer renderer)
        {
            throw new NotImplementedException();
        }
    }
}