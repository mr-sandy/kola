namespace Kola.Service.ResourceBuilding
{
    using System.Collections.Generic;
    using System.Linq;

    using Kola.Service.Extensions;
    using Kola.Service.Services.Models;

    public class AmendmentsResourceBuilder : IResourceBuilder<TemplateAndAmendments>
    {
        public object Build(TemplateAndAmendments model)
        {
            var visitor = new ResourceBuildingAmendmentVisitor(model.Template.Path);

            return model.Amendments.Select((amendment, index) => amendment.Accept(visitor, index));
        }

        public string Location(TemplateAndAmendments model)
        {
            var result = new List<string>();

            result.AddRange(model.Template.Path);
            result.Add("_amendments");

            return result.ToHttpPath();
        }
    }
}