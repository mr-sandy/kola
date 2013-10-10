namespace Kola.Persistence.Surrogates.Extensions
{
    using System;
    using System.Collections.Generic;

    using Kola.Domain;

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