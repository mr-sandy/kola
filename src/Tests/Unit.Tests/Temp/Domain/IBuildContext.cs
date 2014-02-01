namespace Unit.Tests.Temp.Domain
{
    using System;

    using Unit.Tests.Temp.Domain.Specifications;

    public interface IBuildContext
    {
        Func<string, WidgetSpecification> WidgetSpecificationLocator { get; } 
    }
}