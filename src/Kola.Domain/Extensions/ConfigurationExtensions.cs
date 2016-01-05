namespace Kola.Domain.Extensions
{
    using System.Collections.Generic;

    using Kola.Domain.Instances.Config;

    public static class ConfigurationExtensions
    {
        public static IConfiguration Merge(this IConfiguration oldConfiguration, IConfiguration newConfiguration)
        {
            return new Configuration
            {
                ContextItems = oldConfiguration.ContextItems.Merge(newConfiguration.ContextItems)
            };
        }

        public static IConfiguration Merge(this IConfiguration oldConfiguration, IEnumerable<IContextItem> newContextItems)
        {
            return new Configuration
            {
                ContextItems = oldConfiguration.ContextItems.Merge(newContextItems)
            };
        }
    }
}