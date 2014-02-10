namespace Kola.Domain.Templates
{
    using System.Collections.Generic;

    using Kola.Domain.Extensions;
    using Kola.Domain.Instances;
    using Kola.Domain.Instances.Building;
    using Kola.Domain.Specifications;
    using Kola.Domain.Templates.ParameterValues;

    public abstract class NamedComponentTemplate : INamedComponentTemplate
    {
        private readonly List<ParameterTemplate> parameters = new List<ParameterTemplate>();

        protected NamedComponentTemplate(string name, IEnumerable<ParameterTemplate> parameters)
        {
            this.Name = name;

            if (parameters != null)
            {
                this.parameters.AddRange(parameters);
            }
        }

        public string Name { get; private set; }

        public IEnumerable<ParameterTemplate> Parameters
        {
            get { return this.parameters; }
        }

        public void SetParameter(string parameterName, IParameterValue parameterValue, INamedComponentSpecification<INamedComponentTemplate> specification)
        {
            // See if the parameter is already set for this component
            var parameter = this.Parameters.Find(parameterName);
            if (parameter != null)
            {
                parameter.Value = parameterValue;
            }
            else
            {
                // Need to build the parameter template from the specification and then add it to the component
                this.parameters.Add(specification.Parameters.Find(parameterName).Create(parameterValue));
            }
        }

        public abstract void Accept(IComponentTemplateVisitor visitor);

        public abstract IComponentInstance Build(IBuildContext buildContext);
    }
}