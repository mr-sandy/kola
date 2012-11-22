using System;

namespace Kola.Configuration.Plugins
{
    public class ParameterTypeConfigurer : Exception
    {
        private readonly ParameterTypeConfiguration parameterTypeConfiguration;

        internal ParameterTypeConfigurer(ParameterTypeConfiguration parameterTypeConfiguration)
        {
            this.parameterTypeConfiguration = parameterTypeConfiguration;
        }

        public ParameterTypeConfigurer DefaultTo(string value)
        {
            this.parameterTypeConfiguration.DefaultValue = value;
            return this;
        }

        public ParameterTypeConfigurer WithEditor(string editor)
        {
            this.parameterTypeConfiguration.EditorName = editor;
            return this;
        }
    }
}