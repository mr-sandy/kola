namespace Kola.Domain.Extensions
{
    using System.Collections.Generic;

    using Kola.Domain.Instances.Config;

    public static class ConfigurationExtensions
    {
        public static IConfiguration Merge(this IConfiguration oldConfiguration, IConfiguration newConfiguration)
        {
            return new Configuration(
                newConfiguration.CacheControl ?? oldConfiguration.CacheControl,
                oldConfiguration.Conditions.Merge(newConfiguration.Conditions),
                oldConfiguration.ContextItems.Merge(newConfiguration.ContextItems));
        }

        public static IConfiguration Merge(this IConfiguration oldConfiguration, IEnumerable<IContextItem> newContextItems)
        {
            return new Configuration(
                oldConfiguration.CacheControl,
                oldConfiguration.Conditions,
                oldConfiguration.ContextItems.Merge(newContextItems));
        }
    }
}