namespace Kola.Extensions
{
    using Kola.Domain.Templates.Amendments;
    using Kola.Resources;

    internal static class AmendmentResourceExtensions
    {
        public static AddComponentAmendment ToDomain(this AddComponentAmendmentResource resource)
        {
            return new AddComponentAmendment(
                resource.ComponentType.ToComponentName(), 
                resource.TargetPath.ParseComponentPath());
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