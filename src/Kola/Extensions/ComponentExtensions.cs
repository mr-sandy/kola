namespace Kola.Extensions
{
    using System.Collections.Generic;

    using Kola.Domain.Composition;
    using Kola.ResourceBuilders;
    using Kola.Resources;

    internal static class ComponentExtensions
    {
        public static ComponentResource ToResource(this IComponent component, IEnumerable<string> templatePath, IEnumerable<int> componentIndices)
        {
            return new ComponentResourceBuilder().Build(component, componentIndices, templatePath);
        }
    }
}