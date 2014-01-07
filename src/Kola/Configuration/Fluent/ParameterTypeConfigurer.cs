namespace Kola.Configuration.Fluent
{
    using System;

    public class ParameterTypeConfigurer : Exception
    {
        private readonly ParameterTypeSpecification specification;

        internal ParameterTypeConfigurer(ParameterTypeSpecification parameterTypeSpecification)
        {
            this.specification = parameterTypeSpecification;
        }

        public ParameterTypeConfigurer WithDefault(string value)
        {
            this.specification.DefaultValue = value;
            return this;
        }

        public ParameterTypeConfigurer WithEditor(string editor)
        {
            this.specification.EditorName = editor;
            return this;
        }
    }
}