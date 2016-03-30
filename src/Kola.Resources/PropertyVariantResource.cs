namespace Kola.Resources
{
    public class PropertyVariantResource
    {
        public string ContextValue { get; set; }

        public bool IsDefault { get; set; }

        public PropertyValueResource Value { get; set; }
    }
}