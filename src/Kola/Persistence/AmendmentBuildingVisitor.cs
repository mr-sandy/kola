namespace Kola.Persistence
{
    using System.Collections.Generic;

    using Kola.Domain;
    using Kola.Domain.Templates.Amendments;
    using Kola.Domain.Templates.ParameterValues;
    using Kola.Persistence.Extensions;
    using Kola.Persistence.Surrogates;
    using Kola.Persistence.Surrogates.Amendments;

    internal class AmendmentBuildingVisitor : IAmendmentSurrogateVisitor
    {
        private readonly List<IAmendment> amendments = new List<IAmendment>();

        public IEnumerable<IAmendment> Amendments
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

        public void Visit(RemoveComponentAmendmentSurrogate surrogate)
        {
            this.amendments.Add(surrogate.ToDomain());
        }
    }
}