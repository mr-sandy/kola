namespace Kola.Domain.Specifications
{
    using System.Collections.Generic;
    using System.Linq;

    using Kola.Domain.Composition;
    using Kola.Domain.Composition.ParameterValues;

    public abstract class ParameterisedComponentSpecification<T> : IParameterisedComponentSpecification<T>
        where T : IParameterisedComponent
    {
        private readonly List<ParameterSpecification> parameters = new List<ParameterSpecification>();

        protected ParameterisedComponentSpecification(string name, IEnumerable<ParameterSpecification> parameters = null)
        {
            this.Name = name;

            if (parameters != null)
            {
                this.parameters.AddRange(parameters);
            }
        }

        public string Name { get; private set; }

        public IEnumerable<ParameterSpecification> Parameters
        {
            get { return this.parameters; }
        }

        public void AddParameter(ParameterSpecification parameter)
        {
            this.parameters.Add(parameter);
        }

        public abstract T Create();

        protected IEnumerable<Parameter> CreateParameters()
        {
            return this.Parameters.Select(p => p.Create()).Where(p => !(p.Value is UndefinedParameterValue));
        }
    }
}