namespace Kola.Persistence
{
    using System;
    using System.Collections.Generic;

    using Kola.Domain;
    using Kola.Domain.Composition.Amendments;
    using Kola.Persistence.Extensions;
    using Kola.Persistence.Surrogates;
    using Kola.Persistence.Surrogates.Amendments;

    internal class AmendmentSurrogateBuildingVisitor : IAmendmentVisitor
    {
        private readonly List<AmendmentSurrogate> amendmentSurrogates = new List<AmendmentSurrogate>();

        public IEnumerable<AmendmentSurrogate> AmendmentSurrogates
        {
            get { return this.amendmentSurrogates; }
        }

        public void Visit(AddComponentAmendment amendment)
        {
            this.amendmentSurrogates.Add(amendment.ToSurrogate());
        }

        public void Visit(MoveComponentAmendment amendment)
        {
            this.amendmentSurrogates.Add(amendment.ToSurrogate());
        }

        public void Visit(RemoveComponentAmendment amendment)
        {
            this.amendmentSurrogates.Add(amendment.ToSurrogate());
        }

        public void Visit(SetParameterFixedAmendment amendment)
        {
            throw new NotImplementedException();
        }

        public void Visit(SetParameterInheritedAmendment amendment)
        {
            throw new NotImplementedException();
        }

        public void Visit(SetParameterMultilingualAmendment amendment)
        {
            throw new NotImplementedException();
        }
    }
}