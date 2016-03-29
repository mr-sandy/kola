namespace Kola.Service.Services
{
    using System.Collections.Generic;
    using System.Linq;

    using Kola.Domain.Instances.Config;

    public class PluginContextProvider : IPluginContextProvider
    {
        private readonly IEnumerable<IContextProvider> contextProviders;

        public PluginContextProvider(IEnumerable<IContextProvider> contextProviders)
        {
            this.contextProviders = contextProviders;
        }

        public IEnumerable<IContextItem> Contribute(IEnumerable<IContextItem> context)
        {
            return this.contextProviders.SelectMany(p => p.GetContext(context));
        }
    }
}