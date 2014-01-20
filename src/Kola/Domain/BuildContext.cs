namespace Kola.Domain
{
    using System;
    using System.Collections.Generic;

    using Kola.Domain.Specifications;

    public class BuildContext
    {
        public Func<string, WidgetSpecification> WidgetSpecificationFinder { get; set; }

        public IEnumerable<Context> Contexts { get; set; }
    }
}