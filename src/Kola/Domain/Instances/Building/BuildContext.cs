namespace Kola.Domain.Instances.Building
{
    using System;
    using System.Collections.Generic;

    using Kola.Domain.Specifications;

    public class BuildContext : IBuildContext
    {
        private readonly Stack<Queue<ComponentInstance>> areas = new Stack<Queue<ComponentInstance>>();
        private readonly Stack<ContextSet> contexts = new Stack<ContextSet>();

        public Func<string, WidgetSpecification> WidgetSpecificationFinder { get; set; }

        public Stack<Queue<ComponentInstance>> AreaContents
        {
            get { return this.areas; }
        }

        public Stack<ContextSet> ContextSets 
        { 
            get { return this.contexts; }
        }
    }
}