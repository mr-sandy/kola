namespace Kola.Domain.Instances.Building
{
    using System;
    using System.Collections.Generic;

    using Kola.Domain.Specifications;

    public class BuildContext : IBuildContext
    {
        private readonly Stack<Queue<IComponentInstance>> areas = new Stack<Queue<IComponentInstance>>();

        public Func<string, WidgetSpecification> WidgetSpecificationFinder { get; set; }

        public Stack<Queue<IComponentInstance>> AreaContents
        {
            get { return this.areas; }
        }

        public IEnumerable<Context> Contexts { get; set; }
    }
}