namespace Kola.Domain.Templates
{
    using System.Collections.Generic;
    using System.Linq;

    using Kola.Domain.Instances;
    using Kola.Domain.Instances.Building;

    public class AtomTemplate : NamedComponentTemplate
    {
        public AtomTemplate(string name, IEnumerable<ParameterTemplate> parameters)
            : base(name, parameters)
        {
        }

        public override void Accept(IComponentTemplateVisitor visitor)
        {
            visitor.Visit(this);
        }

        public override IComponentInstance Build(IBuildContext buildContext)
        {
            return new AtomInstance(
                this.Name,
                this.Parameters.Select(p => p.Build(buildContext)));
        }
    }
}