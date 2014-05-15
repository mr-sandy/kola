namespace Kola.Extensions
{
    using Kola.Domain.Composition.Amendments;
    using Kola.Resources;

    internal static class AmendmentResourceExtensions
    {
        public static AddComponentAmendment ToDomain(this AddComponentAmendmentResource resource)
        {
            return new AddComponentAmendment(resource.TargetPath.ParseComponentPath(), resource.ComponentType.ToComponentName());
        }

        public static MoveComponentAmendment ToDomain(this MoveComponentAmendmentResource resource)
        {
            return new MoveComponentAmendment(
                resource.SourcePath.ParseComponentPath(),
                resource.TargetPath.ParseComponentPath());
        }

        public static RemoveComponentAmendment ToDomain(this DeleteComponentAmendmentResource resource)
        {
            return new RemoveComponentAmendment(resource.ComponentPath.ParseComponentPath());
        }
    }
}