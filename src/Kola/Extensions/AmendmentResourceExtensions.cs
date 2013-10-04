namespace Kola.Extensions
{
    using System.Linq;

    using Kola.Domain;
    using Kola.Resources;

    internal static class AmendmentResourceExtensions
    {
        public static AddComponentAmendment ToDomain(this AddComponentAmendmentResource resource)
        {
            return new AddComponentAmendment(
                resource.ComponentType, 
                resource.ComponentPath.Split('/').Where(s => !string.IsNullOrWhiteSpace(s)).Select(s => int.Parse(s)), 
                resource.Index);
        }
    }
}