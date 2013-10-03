namespace Kola.Nancy.Extensions
{
    using Kola.Domain;
    using Kola.Resources;

    internal static class AmendmentResourceExtensions
    {
        public static AddComponentAmendment ToDomain(this AddComponentAmendmentResource resource)
        {
            return new AddComponentAmendment(resource.ComponentType, resource.ComponentPath, resource.Index);
        }
    }
}