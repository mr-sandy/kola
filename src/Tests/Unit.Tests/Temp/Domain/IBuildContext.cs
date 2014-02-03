namespace Unit.Tests.Temp.Domain
{
    using System;
    using System.Collections.Generic;

    using Unit.Tests.Temp.Domain.Specifications;
    using Unit.Tests.Temp.Domain.Templates;

    public interface IBuildContext
    {
        Func<string, WidgetSpecification> WidgetSpecificationLocator { get; }

        Stack<Queue<Area>> Areas { get; }
    }
}