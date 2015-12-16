using System.Collections.Generic;
using System.Linq;

namespace Kola.Domain.Composition.PropertyValues
{
    using System.Text.RegularExpressions;

    using Kola.Domain.Instances.Context;

    public class ContextSourcedContentResolver
    {
        private readonly IEnumerable<ContextSet> contextSets;

        public ContextSourcedContentResolver(IEnumerable<ContextSet> contextSets)
        {
            this.contextSets = contextSets ?? Enumerable.Empty<ContextSet>();
        }

        public string Resolve(string source)
        {
            var regex = new Regex("{{.*?}}");
            var matches = regex.Matches(source).Cast<Match>().Select(m => m.Value).Distinct();

            return matches.Aggregate(source, (current, match) => current.Replace(match, this.FindValue(match)));
        }

        private string FindValue(string matchedValue)
        {
            var contextItemName = matchedValue.Substring(2, matchedValue.Length - 4);

            var contextItem = this.contextSets.Select(s => s.Items.FirstOrDefault(c => c.Name == contextItemName)).FirstOrDefault(m => m != null);
            
            return contextItem == null 
                ? string.Empty 
                : contextItem.Value;
        }
    }
}
