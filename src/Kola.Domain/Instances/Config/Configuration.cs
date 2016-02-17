namespace Kola.Domain.Instances.Config
{
    using System.Collections.Generic;
    using System.Linq;

    using Kola.Domain.Instances.Config.Authorisation;

    public class Configuration : IConfiguration
    {
        public Configuration(string cacheControl = null, IEnumerable<ICondition> conditions = null, IEnumerable<IContextItem> contextItems = null)
        {
            this.CacheControl = string.IsNullOrWhiteSpace(cacheControl) ? null : cacheControl;
            this.Conditions = conditions ?? Enumerable.Empty<ICondition>();
            this.ContextItems = contextItems ?? Enumerable.Empty<IContextItem>();
        }

        public string CacheControl { get; }

        public IEnumerable<ICondition> Conditions { get; }

        public IEnumerable<IContextItem> ContextItems { get; } 
    }
}