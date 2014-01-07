namespace Kola.Persistence
{
    using System.Collections.Generic;

    using Kola.Editing;
    using Kola.Editing.Amendments;
    using Kola.Persistence.Extensions;
    using Kola.Persistence.Surrogates;

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

        public void Visit(DeleteComponentAmendment amendment)
        {
            this.amendmentSurrogates.Add(amendment.ToSurrogate());
        }
    }
}