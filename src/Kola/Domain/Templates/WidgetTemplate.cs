namespace Kola.Domain.Templates
{
    using System.Collections.Generic;
    using System.Linq;

    using Kola.Domain.Instances;
    using Kola.Domain.Instances.Building;

    public class WidgetTemplate : NamedComponentTemplate
    {
        public WidgetTemplate(string name, IEnumerable<ParameterTemplate> parameters, IEnumerable<Area> areas)
            : base(name, parameters)
        {
            this.Areas = areas;
        }

        public IEnumerable<Area> Areas { get; private set; }

        public override void Accept(IComponentTemplateVisitor visitor)
        {
            visitor.Visit(this);
        }

        public override IComponentInstance Build(IBuildContext buildContext)
        {
            // Build the content of each area, 
            // before adding it to the context to be 
            // picked up by any corresponding placeholders
            var areas = this.Areas.Select(a => a.Components.Select(c => c.Build(buildContext)).ToList());

            buildContext.Areas.Push(new Queue<IEnumerable<IComponentInstance>>(areas));

            var specification = buildContext.WidgetSpecificationFinder(this.Name);
            var components = specification.Components.Select(c => c.Build(buildContext)).ToList();

            buildContext.Areas.Pop();

            return new WidgetInstance(components);
        }
    }
}