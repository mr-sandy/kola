namespace Kola.Domain.Instances.Config
{
    using System.Collections.Generic;

    using Kola.Domain.Instances.Config.Authorisation;

    public class Configuration : IConfiguration
    {
        public IEnumerable<ICondition> Conditions { get; set; }

        public IEnumerable<IContextItem> ContextItems { get; set; } 
    }
}