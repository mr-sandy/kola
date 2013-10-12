namespace Kola.Resources
{
    using System.Collections.Generic;

    public class TemplateResource : CompositeResource
    {
        public IEnumerable<AmendmentResource> Amendments { get; set; }
    }
}