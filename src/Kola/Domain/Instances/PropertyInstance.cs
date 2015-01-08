namespace Kola.Domain.Instances
{
    public class PropertyInstance
    {
        public PropertyInstance(string name, string value)
        {
            this.Name = name;
            this.Value = value;
        }

        public string Name { get; private set; }

        public string Value { get; private set; }
    }
}