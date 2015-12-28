namespace Kola.Persistence
{
    using System.Collections.Generic;

    using Kola.Domain.Instances.Context;

    public interface IContextSettingsRepository
    {
        IEnumerable<IContextItem> Get(IEnumerable<string> path);
        IEnumerable<IContextItem> Get(string path);
    }
}