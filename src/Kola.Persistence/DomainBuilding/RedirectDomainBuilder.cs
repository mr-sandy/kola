namespace Kola.Persistence.DomainBuilding
{
    using System.Collections.Generic;

    using Kola.Domain.Composition;
    using Kola.Persistence.Surrogates;

    internal class RedirectDomainBuilder
    {
        public Redirect Build(RedirectSurrogate surrogate)
        {
            return new Redirect(surrogate.Location);
        }
    }
}