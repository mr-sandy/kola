namespace Kola.Domain.Instances.Config
{
    using System.Collections.Generic;

    using Kola.Domain.Instances.Config.Authorisation;

    public interface IConfiguration
    {
        string CacheControl { get; }

        IEnumerable<ICondition> Conditions { get; }

        IEnumerable<IContextItem> ContextItems { get; }
    }
}