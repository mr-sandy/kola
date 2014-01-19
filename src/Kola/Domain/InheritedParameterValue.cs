namespace Kola.Domain
{
    using System.Collections.Generic;
    using System.Linq;

    public class InheritedParameterValue : IParameterValue
    {
        public InheritedParameterValue(string key)
        {
            this.Key = key;
        }

        public string Key { get; set; }

        public string Resolve(IEnumerable<Context> contexts)
        {
            foreach (var context in contexts)
            {
                var item = context.Items.Where(i => i.Key.Equals(this.Key)).FirstOrDefault();

                if (item != null)
                {
                    return item.Value;
                }
            }

            return string.Empty;
        }
    }
}