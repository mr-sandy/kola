namespace Kola.Persistence.Surrogates.Extensions
{
    using System.Collections.Generic;

    using Kola.Domain;
    using Kola.Extensions;

    public static class AmendmentExtensions
    {
        public static IEnumerable<AmendmentSurrogate> ToSurrogate(this IEnumerable<Amendment> amendments)
        {
            var visitor = new AmendmentSurrogateBuildingVisitor();

            foreach (var amendment in amendments)
            {
                amendment.Accept(visitor);
            }

            return visitor.AmendmentSurrogates;
        }

        public static IEnumerable<Amendment> ToDomain(this IEnumerable<AmendmentSurrogate> surrogates)
        {
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
                ComponentPath = amendment.ComponentPath.ToComponentPathString(),
                ComponentType = amendment.ComponentType,
                Index = amendment.Index
            };
        }

        public static MoveComponentAmendmentSurrogate ToSurrogate(this MoveComponentAmendment amendment)
        {
            return new MoveComponentAmendmentSurrogate
            {
                ParentComponentPath = amendment.ParentComponentPath.ToComponentPathString(),
                ComponentPath = amendment.ComponentPath.ToComponentPathString(),
                Index = amendment.Index
            };
        }

        public static AddComponentAmendment ToDomain(this AddComponentAmendmentSurrogate surrogate)
        {
            return new AddComponentAmendment(surrogate.ComponentType, surrogate.ComponentPath.ParseComponentPath(), surrogate.Index);
        }

        public static MoveComponentAmendment ToDomain(this MoveComponentAmendmentSurrogate surrogate)
        {
            return new MoveComponentAmendment(surrogate.ParentComponentPath.ParseComponentPath(), surrogate.ComponentPath.ParseComponentPath(), surrogate.Index);
        }
    }
}