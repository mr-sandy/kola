namespace Kola.Domain.Instances.Config
{
    public class ContextItem : IContextItem
    {
        public ContextItem(string name, string value)
        {
            this.Name = name;
            this.Value = value;
        }

        public string Name { get; }

        public string Value { get; }
    }
}