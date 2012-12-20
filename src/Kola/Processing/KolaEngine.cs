using System.Collections.Generic;
using Kola.Configuration.Ideas;
using Kola.Model;

namespace Kola.Processing
{
    public class KolaEngine
    {
        private readonly KolaConfiguration kolaConfiguration;

        public KolaEngine(KolaConfiguration kolaConfiguration)
        {
            this.kolaConfiguration = kolaConfiguration;
        }

        public KolaResult Render(IEnumerable<Component> components)
        {
            //Find the handler for each component
            foreach (var component in components)
            {
                var handler = this.kolaConfiguration.GetHandler(component);
            }
            return new KolaResult {Html = "Hello"};
        }
    }

    public class KolaResult
    {
        public string Html { get; set; }
    }
}