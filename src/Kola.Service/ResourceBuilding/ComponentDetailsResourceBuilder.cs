namespace Kola.Service.ResourceBuilding
{
    using System.Collections.Generic;
    using System.Linq;

    using Kola.Service.Extensions;
    using Kola.Service.Services.Models;

    public class ComponentDetailsResourceBuilder : IResourceBuilder<ComponentDetails>
    {
        public object Build(ComponentDetails model)
        {
            var visitor = new ResourceBuildingComponentVisitor(model.Template.Path);

            return model.Component.Accept(visitor, model.ComponentPath);
        }

        public string Location(ComponentDetails model)
        {
            var result = new List<string>();

            result.AddRange(model.Template.Path);
            result.Add("_components");
            result.AddRange(model.ComponentPath.Select(i => i.ToString()));

            return result.ToHttpPath();
        }
    }
}