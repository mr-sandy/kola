namespace Kola.Resources
{
    public class FixedParameterValueResource : ParameterValueResource
    {
        public string Value { get; set; }

        public override string Type
        {
            get { return "fixed"; }
        }
    }
}