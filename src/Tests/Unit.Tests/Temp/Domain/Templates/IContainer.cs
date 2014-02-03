namespace Unit.Tests.Temp.Domain.Templates
{
    using System.Collections.Generic;

    public interface IContainer
    {
        IEnumerable<IComponentTemplate> Children { get; }
    }
}