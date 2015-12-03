namespace Kola.Service.DomainBuilding
{
    using Kola.Domain.Composition.Amendments;
    using Kola.Resources;
    using Kola.Service.Extensions;

    internal class DomainBuildingAmendmentResourceVisitor : IAmendmentResourceVisitor<IAmendment>
    {
        public IAmendment Visit(AddComponentAmendmentResource resource)
        {
            return new AddComponentAmendment(resource.TargetPath.ParseComponentPath(), resource.ComponentType.ToComponentName());
        }

        public IAmendment Visit(MoveComponentAmendmentResource resource)
        {
            return new MoveComponentAmendment(
                resource.SourcePath.ParseComponentPath(),
                resource.TargetPath.ParseComponentPath());
        }

        public IAmendment Visit(RemoveComponentAmendmentResource resource)
        {
            return new RemoveComponentAmendment(resource.ComponentPath.ParseComponentPath());
        }

        public IAmendment Visit(DuplicateComponentAmendmentResource resource)
        {
            return new DuplicateComponentAmendment(resource.ComponentPath.ParseComponentPath());
        }

        public IAmendment Visit(SetPropertyFixedAmendmentResource resource)
        {
            return new SetPropertyFixedAmendment(resource.ComponentPath.ParseComponentPath(), resource.PropertyName, resource.Value);
        }

        public IAmendment Visit(SetCommentAmendmentResource resource)
        {
            return new SetCommentAmendment(resource.ComponentPath.ParseComponentPath(), resource.Comment);
        }

        public IAmendment Visit(SetPropertyInheritedAmendmentResource resource)
        {
            return new SetPropertyInheritedAmendment(resource.ComponentPath.ParseComponentPath(), resource.PropertyName, resource.Key);
        }
    }
}
