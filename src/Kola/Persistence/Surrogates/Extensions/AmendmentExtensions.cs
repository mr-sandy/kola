namespace Kola.Persistence.Surrogates.Extensions
{
    using System.Collections.Generic;
    using System.Linq;

    using Kola.Domain;

    public static class AmendmentExtensions
    {
        public static AmendmentSurrogate ToSurrogate(this Amendment amendment)
        {
            return new AmendmentSurrogate();
        }

        public static IEnumerable<AmendmentSurrogate> ToSurrogate(this IEnumerable<Amendment> amendments)
        {
            return amendments.Select(ToSurrogate);
        }
    }
}