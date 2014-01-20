namespace Kola.Domain.Instances
{
    using System.Collections.Generic;

    public interface IPage
    {
        IEnumerable<IComponentInstance> Components { get; }
    }
}