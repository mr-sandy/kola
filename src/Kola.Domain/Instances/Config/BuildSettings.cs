namespace Kola.Domain.Instances.Config
{
    using System.Collections.Generic;
    using System.Linq;

    public class BuildSettings : IBuildSettings
    {
        public BuildSettings(IEnumerable<IContextItem> contextItems)
        {
            var context = contextItems as IContextItem[] ?? contextItems.ToArray();

            if (context.Any())
            {
                this.ContextSets.Push(new ContextSet(context));
            }
        }

        public Stack<IDictionary<string, ComponentInstance>> AreaContents { get; } = new Stack<IDictionary<string, ComponentInstance>>();

        public Stack<ContextSet> ContextSets { get; } = new Stack<ContextSet>();
    }
}