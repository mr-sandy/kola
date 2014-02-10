namespace Kola.Domain.Specifications
{
    using System.Collections.Generic;
    using System.Linq;

    using Kola.Domain.Templates;
    using Kola.Domain.Templates.ParameterValues;

    public abstract class NamedComponentSpecification<T> : INamedComponentSpecification<T>
        where T : INamedComponentTemplate
    {
        private readonly List<ParameterSpecification> parameters = new List<ParameterSpecification>();

        protected NamedComponentSpecification(string name, IEnumerable<ParameterSpecification> parameters = null)
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

        protected IEnumerable<ParameterTemplate> CreateParameters()
        {
            return this.Parameters.Select(p => p.Create()).Where(p => !(p.Value is UndefinedParameterValue));
        }
    }
}