namespace Kola.Resources
{
    public class InheritedPropertyValueResource : PropertyValueResource
    {
        public string Key { get; set; }

        public override string Type => "inherited";
    }
}