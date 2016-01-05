namespace Kola.Domain.Instances.Config
{
    using System.Collections.Generic;

    public interface IConfiguration
    {
        IEnumerable<IAuthCheck> AuthChecks { get; }

        IEnumerable<IContextItem> ContextItems { get; }
    }
}