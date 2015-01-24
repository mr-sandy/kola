namespace Kola.Domain.Instances.Context
{
    using System;
    using System.Collections.Generic;

    using Kola.Domain.Specifications;

    public class BuildContext : IBuildContext
    {
        private readonly Stack<IDictionary<string, ComponentInstance>> areas = new Stack<IDictionary<string, ComponentInstance>>();
        private readonly Stack<ContextSet> contexts = new Stack<ContextSet>();

        public Func<string, WidgetSpecification> WidgetSpecificationFinder { get; set; }

        public Stack<IDictionary<string, ComponentInstance>> AreaContents
        {
            get { return this.areas; }
        }

        public Stack<ContextSet> ContextSets 
        { 
            get { return this.contexts; }
        }
    }
}