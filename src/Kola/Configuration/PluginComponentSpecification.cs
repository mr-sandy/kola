namespace Kola.Configuration
{
    using System;
    using System.Collections.Generic;

    using Kola.Domain;

    public abstract class PluginComponentSpecification : IPluginComponentSpecification
    {
        private readonly List<ParameterSpecification> parameters = new List<ParameterSpecification>();

        protected PluginComponentSpecification(string name)
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

        public abstract IComponent Create();
    }
}