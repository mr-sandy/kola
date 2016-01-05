namespace Kola.Domain.Instances.Config
{
    using System.Collections.Generic;

    public class Configuration : IConfiguration
    {
        public IEnumerable<IAuthCheck> AuthChecks { get; }

        public IEnumerable<IContextItem> ContextItems { get; set; } 
    }
}