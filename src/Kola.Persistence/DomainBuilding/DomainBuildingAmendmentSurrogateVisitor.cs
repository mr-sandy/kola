namespace Kola.Persistence.DomainBuilding
{
    using System;

    using Kola.Domain.Composition.Amendments;
    using Kola.Persistence.Extensions;
    using Kola.Persistence.Surrogates.Amendments;

    internal class DomainBuildingAmendmentSurrogateVisitor : IAmendmentSurrogateVisitor<IAmendment>
    {
        public IAmendment Visit(AddComponentAmendmentSurrogate surrogate)
        {
            return new AddComponentAmendment(surrogate.TargetPath.ParseComponentPath(), surrogate.ComponentType);
        }

        public IAmendment Visit(MoveComponentAmendmentSurrogate surrogate)
        {
            return new MoveComponentAmendment(surrogate.SourcePath.ParseComponentPath(), surrogate.TargetPath.ParseComponentPath());
        }

        public IAmendment Visit(RemoveComponentAmendmentSurrogate surrogate)
        {
            return new RemoveComponentAmendment(surrogate.ComponentPath.ParseComponentPath());
        }

        public IAmendment Visit(DuplicateComponentAmendmentSurrogate surrogate)
        {
            return new DuplicateComponentAmendment(surrogate.ComponentPath.ParseComponentPath());
        }

        public IAmendment Visit(SetPropertyFixedAmendmentSurrogate surrogate)
        {
            return new SetPropertyFixedAmendment(surrogate.ComponentPath.ParseComponentPath(), surrogate.PropertyName, surrogate.FixedValue);
        }

        public IAmendment Visit(SetCommentAmendmentSurrogate surrogate)
        {
            return new SetCommentAmendment(surrogate.ComponentPath.ParseComponentPath(), surrogate.Comment);
        }

        public IAmendment Visit(SetPropertyInheritedAmendmentSurrogate surrogate)
        {
            return new SetPropertyInheritedAmendment(surrogate.ComponentPath.ParseComponentPath(), surrogate.PropertyName, surrogate.Key);
        }

        public IAmendment Visit(ClearPropertyAmendmentSurrogate surrogate)
        {
            return new ClearPropertyAmendment(surrogate.ComponentPath.ParseComponentPath(), surrogate.PropertyName);
        }
    }
}
