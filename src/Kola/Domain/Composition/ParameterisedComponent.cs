namespace Kola.Domain.Composition
{
    using System.Collections.Generic;

    using Kola.Domain.Composition.ParameterValues;
    using Kola.Domain.Extensions;
    using Kola.Domain.Instances;
    using Kola.Domain.Instances.Building;
    using Kola.Domain.Specifications;

    public abstract class ParameterisedComponent : IParameterisedComponent
    {
        private readonly List<Parameter> parameters = new List<Parameter>();

        protected ParameterisedComponent(string name, IEnumerable<Parameter> parameters)
        {
            this.Name = name;

            if (parameters != null)
            {
                this.parameters.AddRange(parameters);
            }
        }

        public string Name { get; private set; }

        public IEnumerable<Parameter> Parameters
        {
            get { return this.parameters; }
        }

        public void SetParameter(string parameterName, IParameterValue parameterValue, IParameterisedComponentSpecification<IParameterisedComponent> specification)
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

        public abstract void Accept(IComponentVisitor visitor);

        public abstract IComponentInstance Build(IBuildContext buildContext);
    }
}