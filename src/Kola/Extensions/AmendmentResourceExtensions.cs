namespace Kola.Extensions
{
    using Kola.Domain;
    using Kola.Resources;

    internal static class AmendmentResourceExtensions
    {
        public static AddComponentAmendment ToDomain(this AddComponentAmendmentResource resource)
        {
            return new AddComponentAmendment(
                resource.ComponentType, 
                resource.ComponentPath.ParseComponentPath(), 
                resource.Index);
        }

        public static MoveComponentAmendment ToDomain(this MoveComponentAmendmentResource resource)
        {
            return new MoveComponentAmendment(
                resource.ParentComponentPath.ParseComponentPath(),
                resource.ComponentPath.ParseComponentPath(),
                resource.Index);
        }
    }
}