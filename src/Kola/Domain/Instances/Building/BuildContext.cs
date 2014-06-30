namespace Kola.Domain.Instances.Building
{
    using System;
    using System.Collections.Generic;

    using Kola.Domain.Specifications;

    public class BuildContext : IBuildContext
    {
        private readonly Stack<Queue<AreaInstance>> areas = new Stack<Queue<AreaInstance>>();

        public Func<string, WidgetSpecification> WidgetSpecificationFinder { get; set; }

        public Stack<Queue<AreaInstance>> Areas
        {
            get { return this.areas; }
        }

        public IEnumerable<Context> Contexts { get; set; }
    }
}