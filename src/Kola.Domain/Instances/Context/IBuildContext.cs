namespace Kola.Domain.Instances.Context
{
    using System.Collections.Generic;

    public interface IBuildContext
    {
        Stack<IDictionary<string, ComponentInstance>> AreaContents { get; }

        Stack<ContextSet> ContextSets { get; }
    }
}