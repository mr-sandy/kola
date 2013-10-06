namespace Kola.Persistence.Surrogates.Extensions
{
    using System;
    using System.Collections.Generic;

    using Kola.Domain;

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
    }
}