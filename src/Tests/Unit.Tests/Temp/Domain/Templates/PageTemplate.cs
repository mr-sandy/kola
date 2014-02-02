namespace Unit.Tests.Temp.Domain.Templates
{
    using System;
    using System.Collections.Generic;

    using Unit.Tests.Temp.Domain.Instances;

    public class PageTemplate : ITemplate
    {
        public IEnumerable<IComponent> Components
        {
            get
            {
                throw new NotImplementedException();
            }
        }


        public void Add(AtomTemplate atom, IEnumerable<int> path)
        {
        }

        public void Add(ContainerTemplate container, IEnumerable<int> path)
        {
        }

        public void Add(WidgetTemplate widget, IEnumerable<int> path)
        {
        }

        public IInstance Build(IBuildContext buildContext)
        {
            return new PageInstance();
        }
    }
}