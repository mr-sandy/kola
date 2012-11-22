using System;
using System.Collections.Generic;

namespace Kola.Configuration
{
    internal abstract class ComponentConfiguration
    {
        private readonly List<ParameterConfiguration> parameters = new List<ParameterConfiguration>();

        public Type HandlerType { get; set; }

        public string ViewName { get; set; }

        public IEnumerable<ParameterConfiguration> Parameters
        {
            get { return this.parameters; }
        }

        public void ConfigureParameter(string parameterName, string parameterType, string parameterValue)
        {
            this.parameters.Add(new ParameterConfiguration(parameterName, parameterType, parameterValue));
        }
    }
}