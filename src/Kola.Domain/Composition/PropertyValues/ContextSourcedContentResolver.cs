namespace Kola.Domain.Composition.PropertyValues
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    using Kola.Domain.Instances.Config;

    public class ContextSourcedContentResolver
    {
        private readonly IEnumerable<IEnumerable<IContextItem>> contextSets;

        public ContextSourcedContentResolver(IEnumerable<IEnumerable<IContextItem>> contextSets)
        {
            this.contextSets = contextSets ?? Enumerable.Empty<IEnumerable<IContextItem>>();
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

            var contextItem = this.contextSets.Select(s => s.FirstOrDefault(c => c.Name == contextItemName)).FirstOrDefault(m => m != null);
            
            return contextItem == null 
                ? string.Empty 
                : contextItem.Value;
        }
    }
}
