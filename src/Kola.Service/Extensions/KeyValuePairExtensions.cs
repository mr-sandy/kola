namespace Kola.Service.Extensions
{
    using System.Collections.Generic;

    using Kola.Domain.Instances.Config;

    internal static class KeyValuePairExtensions
    {
        public static ContextItem ToContextItem(this KeyValuePair<string, string> pair)
        {
            return new ContextItem(pair.Key, pair.Value);
        }
    }
}