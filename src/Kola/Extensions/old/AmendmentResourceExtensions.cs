namespace Kola.Extensions
{
    using Kola.Domain.Amendments;
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

        public static DeleteComponentAmendment ToDomain(this DeleteComponentAmendmentResource resource)
        {
            return new DeleteComponentAmendment(resource.ComponentPath.ParseComponentPath());
        }
    }
}