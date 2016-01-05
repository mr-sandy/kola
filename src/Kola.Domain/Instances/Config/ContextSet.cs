namespace Kola.Domain.Instances.Config
{
    using System.Collections.Generic;

    public class ContextSet
    {
        public ContextSet(IEnumerable<IContextItem> items, string languageCode = "")
        {
            this.Items = items;
            this.LanguageCode = languageCode;
        }

        public IEnumerable<IContextItem> Items { get; private set; }

        public string LanguageCode { get; private set; }
    }
}