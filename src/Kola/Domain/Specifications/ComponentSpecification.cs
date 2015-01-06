namespace Kola.Domain.Specifications
{
    using System.Collections.Generic;

    using Kola.Domain.Composition;

    public abstract class ComponentSpecification<T> : IComponentSpecification<T>
        where T : IParameterisedComponent
    {
        private readonly List<ParameterSpecification> parameters = new List<ParameterSpecification>();

        protected ComponentSpecification(string name, IEnumerable<ParameterSpecification> parameters = null)
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

        public abstract TV Accept<TV>(IComponentSpecificationVisitor<TV> visitor);

        public abstract T Create();
    }
}