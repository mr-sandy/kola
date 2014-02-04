namespace Kola.Domain.Templates
{
    using System;
    using System.Linq;

    using Kola.Domain.Instances;

    public class PlaceholderTemplate : IComponentTemplate
    {
        public void Accept(IComponentTemplateVisitor visitor)
        {
            visitor.Visit(this);
        }

        public IComponentInstance Build(IBuildContext buildContext)
        {
            var area = buildContext.Areas.Peek().Dequeue();

            return new PlaceholderInstance(area.Components.Select(c => c.Build(buildContext)).ToList());
        }
    }
}