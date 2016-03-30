namespace Kola.Domain.Instances.Config
{
    using System.Collections.Generic;

    public interface IBuildData
    {
        Stack<IDictionary<string, ComponentInstance>> AreaContents { get; }

        Stack<IEnumerable<IContextItem>> ContextSets { get; }
    }
}