using System;
using System.Collections.Generic;

namespace Kola.Configuration
{
    internal class ComponentConfiguration
    {
        private readonly List<ParameterConfiguration> parameters = new List<ParameterConfiguration>();

        public ComponentConfiguration(string name)
        {
            this.Name = name;
        }

        public Type HandlerType { get; set; }

        public string Name { get; private set; }

        public CacheType CacheType { get; set; }

        public int CacheDuration { get; set; }

        public string ViewName { get; set; }

        public IEnumerable<ParameterConfiguration> Parameters
        {
            get { return this.parameters; }
        }

        public void AddParameter(ParameterConfiguration parameterConfiguration)
        {
            this.parameters.Add(parameterConfiguration);
        }
    }
}