namespace Kola.Domain.Instances.Building
{
    using System;
    using System.Collections.Generic;

    using Kola.Domain.Specifications;
    using Kola.Domain.Templates;

    public class BuildContext : IBuildContext
    {
        private readonly Stack<Queue<Area>> areas = new Stack<Queue<Area>>();

        public Func<string, WidgetSpecification> WidgetSpecificationFinder { get; set; }

        public Stack<Queue<Area>> Areas
        {
            get { return this.areas; }
        }

        public IEnumerable<Context> Contexts { get; set; }
    }
}