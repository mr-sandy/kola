namespace Kola.Persistence.Extensions
{
    using System.Collections.Generic;

    using Kola.Domain.Composition.Amendments;
    using Kola.Extensions;
    using Kola.Persistence.Surrogates.Amendments;

    public static class AmendmentExtensions
    {
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

        public static AddComponentAmendment ToDomain(this AddComponentAmendmentSurrogate surrogate)
        {
            return new AddComponentAmendment(surrogate.TargetPath.ParseComponentPath(), surrogate.ComponentType);
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