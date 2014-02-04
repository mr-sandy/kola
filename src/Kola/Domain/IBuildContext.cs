namespace Kola.Domain
{
    using System;
    using System.Collections.Generic;

    using Kola.Domain.Specifications;
    using Kola.Domain.Templates;

    public interface IBuildContext
    {
        Func<string, WidgetSpecification> WidgetSpecificationFinder { get; }

        Stack<Queue<Area>> Areas { get; }

        IEnumerable<Context> Contexts { get; }
    }
}