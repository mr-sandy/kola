namespace Kola.Persistence.SurrogateBuilding
{
    using System;

    using Kola.Domain.Composition.Amendments;
    using Kola.Extensions;
    using Kola.Persistence.Surrogates.Amendments;

    internal class SurrogateBuildingAmendmentVisitor : IAmendmentVisitor<AmendmentSurrogate>
    {
        public AmendmentSurrogate Visit(AddComponentAmendment amendment)
        {
            return new AddComponentAmendmentSurrogate
            {
                TargetPath = amendment.TargetPath.ToComponentPathString(),
                ComponentType = amendment.ComponentName,
            };
        }

        public AmendmentSurrogate Visit(MoveComponentAmendment amendment)
        {
            return new MoveComponentAmendmentSurrogate
            {
                SourcePath = amendment.SourcePath.ToComponentPathString(),
                TargetPath = amendment.TargetPath.ToComponentPathString()
            };
        }

        public AmendmentSurrogate Visit(RemoveComponentAmendment amendment)
        {
            return new RemoveComponentAmendmentSurrogate
            {
                ComponentPath = amendment.ComponentPath.ToComponentPathString(),
            };
        }

        public AmendmentSurrogate Visit(SetParameterFixedAmendment amendment)
        {
            return new SetParameterFixedAmendmentSurrogate
            {
                ComponentPath = amendment.ComponentPath.ToComponentPathString(),
                ParameterName = amendment.ParameterName,
                FixedValue = amendment.FixedValue
            };
        }

        public AmendmentSurrogate Visit(SetParameterInheritedAmendment amendment)
        {
            throw new NotImplementedException();
        }

        public AmendmentSurrogate Visit(SetParameterMultilingualAmendment amendment)
        {
            throw new NotImplementedException();
        }
    }
}