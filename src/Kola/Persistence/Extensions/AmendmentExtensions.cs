namespace Kola.Persistence.Extensions
{
    using System.Collections.Generic;

    using Kola.Domain.Composition.Amendments;
    using Kola.Extensions;
    using Kola.Persistence.Surrogates;
    using Kola.Persistence.Surrogates.Amendments;

    public static class AmendmentExtensions
    {
        public static IEnumerable<AmendmentSurrogate> ToSurrogate(this IEnumerable<IAmendment> amendments)
        {
            var visitor = new AmendmentSurrogateBuildingVisitor();

            foreach (var amendment in amendments)
            {
                amendment.Accept(visitor);
            }

            return visitor.AmendmentSurrogates;
        }

        public static IEnumerable<IAmendment> ToDomain(this IEnumerable<AmendmentSurrogate> surrogates)
        {
            if (surrogates == null)
            {
                return null;
            }

            var visitor = new AmendmentBuildingVisitor();

            foreach (var surrogate in surrogates)
            {
                surrogate.Accept(visitor);
            }

            return visitor.Amendments;
        }

        public static AddComponentAmendmentSurrogate ToSurrogate(this AddComponentAmendment amendment)
        {
            return new AddComponentAmendmentSurrogate
            {
                TargetPath = amendment.TargetPath.ToComponentPathString(),
                ComponentType = amendment.ComponentName,
            };
        }

        public static MoveComponentAmendmentSurrogate ToSurrogate(this MoveComponentAmendment amendment)
        {
            return new MoveComponentAmendmentSurrogate
            {
                SourcePath = amendment.SourcePath.ToComponentPathString(),
                TargetPath = amendment.TargetPath.ToComponentPathString()
            };
        }

        public static RemoveComponentAmendmentSurrogate ToSurrogate(this RemoveComponentAmendment amendment)
        {
            return new RemoveComponentAmendmentSurrogate
            {
                ComponentPath = amendment.ComponentPath.ToComponentPathString(),
            };
        }

        public static AddComponentAmendment ToDomain(this AddComponentAmendmentSurrogate surrogate)
        {
            return new AddComponentAmendment(surrogate.ComponentType, surrogate.TargetPath.ParseComponentPath());
        }

        public static MoveComponentAmendment ToDomain(this MoveComponentAmendmentSurrogate surrogate)
        {
            return new MoveComponentAmendment(surrogate.SourcePath.ParseComponentPath(), surrogate.TargetPath.ParseComponentPath());
        }

        public static RemoveComponentAmendment ToDomain(this RemoveComponentAmendmentSurrogate surrogate)
        {
            return new RemoveComponentAmendment(surrogate.ComponentPath.ParseComponentPath());
        }
    }
}