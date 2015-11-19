namespace Kola.Service.ResourceBuilding
{
    using System.Collections.Generic;
    using System.Linq;

    using Kola.Domain.Composition;
    using Kola.Domain.Composition.Amendments;
    using Kola.Service.Extensions;
    using Kola.Service.Services.Models;

    public class AmendmentDetailsResourceBuilder : IResourceBuilder<AmendmentDetails>
    {
        public object Build(AmendmentDetails model)
        {
            var index = this.GetAmendmentIndex(model.Template, model.Amendment);

            var visitor = new ResourceBuildingAmendmentVisitor(model.Template.Path);

            return model.Amendment.Accept(visitor, index);

        }

        public string Location(AmendmentDetails widgetSpecification)
        {
            var result = new List<string>();

            result.AddRange(new[] { "_kola", "templates" });
            result.AddRange(widgetSpecification.Template.Path);
            result.Add("_amendments");
            result.Add(this.GetAmendmentIndex(widgetSpecification.Template, widgetSpecification.Amendment).ToString());

            return result.ToHttpPath();
        }

        private int GetAmendmentIndex(Template template, IAmendment amendment)
        {
            return template.Amendments.Select((a, i) => new { Amendment = a, Index = i }).First(a => a.Amendment == amendment).Index;
        }
    }
}