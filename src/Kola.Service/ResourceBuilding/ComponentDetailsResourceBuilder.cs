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

        public string Location(ComponentDetails component)
        {
            throw new System.NotImplementedException("I don't think this is used");
            //return $"/_kola/template/components?templatePath={component.Template.Path.ToHttpPath()}&componentPath={component.ComponentPath.Select(i => i.ToString()).ToHttpPath()}";
        }
    }
}