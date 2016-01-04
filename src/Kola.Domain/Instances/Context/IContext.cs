namespace Kola.Domain.Instances.Context
{
    using System.Collections.Generic;

    public interface IContext
    {
        IEnumerable<IAuthCheck> AuthChecks { get; }

        IEnumerable<IContextItem> ContextItems { get; }
    }
}