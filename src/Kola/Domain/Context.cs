namespace Kola.Domain
{
    using System.Collections.Generic;

    public class Context
    {
        public string LanguageCode { get; set; }

        public IEnumerable<ContextItem> Items { get; set; }
    }
}