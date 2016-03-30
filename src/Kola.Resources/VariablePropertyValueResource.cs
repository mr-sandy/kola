namespace Kola.Resources
{
    public class VariablePropertyValueResource : PropertyValueResource
    {
        public string ContextName { get; set; }

        public PropertyVariantResource[] Variants { get; set; }

        public override string Type => "variable";
    }
}