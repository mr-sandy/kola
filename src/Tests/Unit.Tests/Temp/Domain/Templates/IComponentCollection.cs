namespace Unit.Tests.Temp.Domain.Templates
{
    using System.Collections.Generic;

    public interface IComponentCollection
    {
        IEnumerable<IComponentTemplate> Components { get; }
    }
}