namespace Kola.Service.Services
{
    using System.Collections.Generic;

    using Kola.Domain.Instances.Config;

    public interface IPluginContextProvider
    {
        IEnumerable<IContextItem> Contribute(IEnumerable<IContextItem> context);
    }
}