namespace Kola.Domain.Instances.Context
{
    using System.Collections.Generic;

    public class Context : IContext
    {
        public IEnumerable<IAuthCheck> AuthChecks { get; }

        public IEnumerable<IContextItem> ContextItems { get; set; } 
    }
}