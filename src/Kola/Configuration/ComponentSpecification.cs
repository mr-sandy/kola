namespace Kola.Configuration
{
    using System;
    using System.Collections.Generic;

    public class ComponentSpecification
    {
        private readonly List<ParameterSpecification> parameters = new List<ParameterSpecification>();

        public ComponentSpecification(string name)
        {
            this.Name = name;
        }

        public Type HandlerType { get; set; }

        public string Name { get; private set; }

        public CacheType CacheType { get; set; }

        public int CacheDuration { get; set; }

        public string ViewName { get; set; }

        public IEnumerable<ParameterSpecification> Parameters
        {
            get { return this.parameters; }
        }

        public void AddParameter(ParameterSpecification parameter)
        {
            this.parameters.Add(parameter);
        }
    }
}