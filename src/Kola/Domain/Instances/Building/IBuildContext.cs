namespace Kola.Domain.Instances.Building
{
    using System;
    using System.Collections.Generic;

    using Kola.Domain.Specifications;

    public interface IBuildContext
    {
        Func<string, WidgetSpecification> WidgetSpecificationFinder { get; }

        Stack<Queue<ComponentInstance>> AreaContents { get; }

        IEnumerable<Context> Contexts { get; }
    }
}