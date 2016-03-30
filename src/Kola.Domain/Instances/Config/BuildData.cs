namespace Kola.Domain.Instances.Config
{
    using System.Collections.Generic;
    using System.Linq;

    public class BuildData : IBuildData
    {
        public BuildData(IEnumerable<IContextItem> contextItems)
        {
            var context = contextItems ?? Enumerable.Empty<IContextItem>();

            if (context.Any())
            {
                this.ContextSets.Push(context);
            }
        }

        public Stack<IDictionary<string, ComponentInstance>> AreaContents { get; } = new Stack<IDictionary<string, ComponentInstance>>();

        public Stack<IEnumerable<IContextItem>> ContextSets { get; } = new Stack<IEnumerable<IContextItem>>();
    }
}