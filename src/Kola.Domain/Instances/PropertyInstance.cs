namespace Kola.Domain.Instances
{
    using Kola.Domain.Instances.Config;

    public class PropertyInstance : IContextItem
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