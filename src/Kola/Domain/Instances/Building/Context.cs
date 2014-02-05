namespace Kola.Domain.Instances.Building
{
    using System.Collections.Generic;

    public class Context
    {
        public string LanguageCode { get; set; }

        public IEnumerable<ContextItem> Items { get; set; }
    }
}