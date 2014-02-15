namespace Kola.Domain.Instances.Building
{
    using System;
    using System.Collections.Generic;

    using Kola.Domain.Specifications;
    using Kola.Domain.Composition;

    public class BuildContext : IBuildContext
    {
        private readonly Stack<Queue<IEnumerable<IComponentInstance>>> areas = new Stack<Queue<IEnumerable<IComponentInstance>>>();

        public Func<string, WidgetSpecification> WidgetSpecificationFinder { get; set; }

        public Stack<Queue<IEnumerable<IComponentInstance>>> Areas
        {
            get { return this.areas; }
        }

        public IEnumerable<Context> Contexts { get; set; }
    }
}