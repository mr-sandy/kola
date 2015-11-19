namespace Kola.Resources
{
    using System.Collections.Generic;

    public class UndoAmendmentResource
    {
        public AmendmentResource[] Amendments { get; set; }

        public IEnumerable<LinkResource> Links { get; set; }
    }
}