namespace Kola.Persistence.DomainBuilding
{
    using System.Collections.Generic;
    using System.Linq;

    using Kola.Domain.Composition;
    using Kola.Persistence.Surrogates;

    internal class TemplateDomainBuilder
    {
        private readonly IEnumerable<string> path;

        public TemplateDomainBuilder(IEnumerable<string> path)
        {
            this.path = path;
        }

        public Template Build(TemplateSurrogate surrogate)
        {
            var componentBuilder = new DomainBuildingComponentSurrogateVisitor();
            var amendmentBuilder = new DomainBuildingAmendmentSurrogateVisitor();

            return new Template(
                this.path,
                surrogate.Components.Select(c => c.Accept(componentBuilder)).ToArray(),
                surrogate.Amendments.Select(a => a.Accept(amendmentBuilder)).ToArray());
        }
    }
}