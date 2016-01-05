namespace Kola.Domain.Instances.Config
{
    using System.Collections.Generic;

    public interface IBuildSettings
    {
        Stack<IDictionary<string, ComponentInstance>> AreaContents { get; }

        Stack<ContextSet> ContextSets { get; }
    }
}