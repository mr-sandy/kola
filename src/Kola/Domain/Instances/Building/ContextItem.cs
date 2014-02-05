namespace Kola.Domain.Instances.Building
{
    public class ContextItem
    {
        public ContextItem(string key, string value)
        {
            this.Key = key;
            this.Value = value;
        }

        public string Key { get; private set; }

        public string Value { get; private set; }
    }
}