namespace Kola.Configuration.Fluent
{
    using System;

    public class PropertyTypeConfigurer : Exception
    {
        private readonly PropertyTypeSpecification specification;

        internal PropertyTypeConfigurer(PropertyTypeSpecification propertyTypeSpecification)
        {
            this.specification = propertyTypeSpecification;
        }

        public PropertyTypeConfigurer WithDefault(string value)
        {
            this.specification.DefaultValue = value;
            return this;
        }

        public PropertyTypeConfigurer WithEditor(string editor)
        {
            this.specification.EditorName = editor;
            return this;
        }
    }
}