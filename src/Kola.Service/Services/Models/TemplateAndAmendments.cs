namespace Kola.Service.Services.Models
{
    using System.Collections.Generic;

    using Kola.Domain.Composition;
    using Kola.Domain.Composition.Amendments;

    public class TemplateAndAmendments
    {
        public TemplateAndAmendments(Template template, IEnumerable<IAmendment> amendments)
        {
            this.Template = template;
            this.Amendments = amendments;
        }

        public Template Template { get; }

        public IEnumerable<IAmendment> Amendments { get; }
    }
}