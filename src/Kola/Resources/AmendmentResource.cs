namespace Kola.Resources
{
    using System.Collections.Generic;

    public abstract class AmendmentResource
    {
        public abstract string Type { get; }

        public int Id { get; set; }

        public IEnumerable<LinkResource> Links { get; set; }

        public abstract T Accept<T>(IAmendmentResourceVisitor<T> visitor);
    }
}