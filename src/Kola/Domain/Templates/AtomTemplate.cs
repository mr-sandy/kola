namespace Kola.Domain.Templates
{
    using System.Collections.Generic;
    using System.Linq;

    using Kola.Domain.Instances;

    public class AtomTemplate : IParameterisedComponent
    {
        public AtomTemplate(string name, IEnumerable<ParameterTemplate> parameters)
        {
            this.Name = name;
            this.Parameters = parameters ?? Enumerable.Empty<ParameterTemplate>();
        }

        public string Name { get; private set; }

        public IEnumerable<ParameterTemplate> Parameters { get; private set; }

        public void Accept(IComponentTemplateVisitor visitor)
        {
            visitor.Visit(this);
        }

        public IComponentInstance Build(IBuildContext buildContext)
        {
            return new AtomInstance(
                this.Name,
                this.Parameters.Select(p => p.Build(buildContext)));
        }
    }
}