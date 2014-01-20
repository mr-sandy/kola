namespace Kola.Domain.Templates.ParameterValues
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

        public string Resolve(BuildContext buildContext)
        {
            foreach (var context in buildContext.Contexts)
            {
                var item = context.Items.Where(i => i.Key.Equals(this.Key)).FirstOrDefault();

                if (item != null)
                {
                    return item.Value;
                }
            }

            return string.Empty;
        }

        public T Accept<T>(IParameterValueVisitor<T> visitor)
        {
            return visitor.Visit(this);
        }
    }
}