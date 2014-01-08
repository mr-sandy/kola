namespace Kola.Persistence
{
    using System.Collections.Generic;

    using Kola.Domain.Amendments;
    using Kola.Persistence.Extensions;
    using Kola.Persistence.Surrogates;

    internal class AmendmentBuildingVisitor : IAmendmentSurrogateVisitor
    {
        private readonly List<Amendment> amendments = new List<Amendment>();

        public IEnumerable<Amendment> Amendments
        {
            get { return this.amendments; }
        }

        public void Visit(AddComponentAmendmentSurrogate surrogate)
        {
            this.amendments.Add(surrogate.ToDomain());
        }

        public void Visit(MoveComponentAmendmentSurrogate surrogate)
        {
            this.amendments.Add(surrogate.ToDomain());
        }

        public void Visit(DeleteComponentAmendmentSurrogate surrogate)
        {
            this.amendments.Add(surrogate.ToDomain());
        }
    }
}