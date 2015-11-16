namespace Kola.Service.ResourceBuilding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Kola.Domain.Composition;
    using Kola.Domain.Composition.Amendments;
    using Kola.Resources;
    using Kola.Service.Extensions;
    using Kola.Service.Services.Models;

    public class AmendmentResourceBuilder : IResourceBuilder<TemplateAndAmendment>
    {
        public object Build(TemplateAndAmendment model)
        {
            var index = this.GetAmendmentIndex(model.Template, model.Amendment);

            var visitor = new ResourceBuildingAmendmentVisitor(model.Template.Path);

            return model.Amendment.Accept(visitor, index);

        }

        public string Location(TemplateAndAmendment model)
        {
            var result = new List<string>();

            result.AddRange(model.Template.Path);
            result.Add("_amendments");
            result.Add(this.GetAmendmentIndex(model.Template, model.Amendment).ToString());

            return result.ToHttpPath();
        }

        private int GetAmendmentIndex(Template template, IAmendment amendment)
        {
            return template.Amendments.Select((a, i) => new { Amendment = a, Index = i }).First(a => a.Amendment == amendment).Index;
        }
    }
}