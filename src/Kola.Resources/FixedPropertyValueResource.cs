namespace Kola.Resources
{
    public class FixedPropertyValueResource : PropertyValueResource
    {
        public string Value { get; set; }

        public override string Type => "fixed";
    }
}