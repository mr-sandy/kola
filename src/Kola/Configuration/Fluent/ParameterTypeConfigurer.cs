using System;

namespace Kola.Configuration.Fluent
{
    public class ParameterTypeConfigurer : Exception
    {
        private readonly ParameterTypeConfiguration configuration;

        internal ParameterTypeConfigurer(ParameterTypeConfiguration parameterTypeConfiguration)
        {
            this.configuration = parameterTypeConfiguration;
        }

        public ParameterTypeConfigurer WithDefault(string value)
        {
            this.configuration.DefaultValue = value;
            return this;
        }

        public ParameterTypeConfigurer WithEditor(string editor)
        {
            this.configuration.EditorName = editor;
            return this;
        }
    }
}