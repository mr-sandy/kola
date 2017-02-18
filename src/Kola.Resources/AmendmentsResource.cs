namespace Kola.Resources
{
    using System.Collections.Generic;

    public class AmendmentsResource
    {
        public AmendmentResource[] Amendments { get; set; }

        public IEnumerable<LinkResource> Links { get; set; }
    }
}