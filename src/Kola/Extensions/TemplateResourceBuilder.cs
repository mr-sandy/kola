namespace Kola.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Kola.Domain.Composition;
    using Kola.Resources;

    internal class TemplateResourceBuilder
    {
        public TemplateResource Build(Template template)
        {
            //var visitor = new ComponentResourceBuildingVisitor();

            //var components = visitor.Build(template.Components);

            return new TemplateResource
                {
                };
        }
    }

}