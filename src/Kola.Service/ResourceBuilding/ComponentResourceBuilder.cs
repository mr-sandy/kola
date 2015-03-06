namespace Kola.Service.ResourceBuilding
{
    using System.Collections.Generic;

    using Kola.Domain.Composition;
    using Kola.Resources;

    public class ComponentResourceBuilder
    {
        public ComponentResource Build(IComponent component, IEnumerable<int> path, IEnumerable<string> templatePath)
        {
            var visitor = new ResourceBuildingComponentVisitor(templatePath);

            return component.Accept(visitor, path);
        }
    }
}