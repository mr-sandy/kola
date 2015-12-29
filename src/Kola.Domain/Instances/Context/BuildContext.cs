namespace Kola.Domain.Instances.Context
{
    using System.Collections.Generic;

    public class BuildContext : IBuildContext
    {
        public Stack<IDictionary<string, ComponentInstance>> AreaContents { get; } = new Stack<IDictionary<string, ComponentInstance>>();

        public Stack<ContextSet> ContextSets { get; } = new Stack<ContextSet>();
    }
}