using System.Collections.Generic;

namespace Kola.Domain
{
    public class Template
    {
        public Template(IEnumerable<string> path)
        {
            this.Path = path;
        }

        public IEnumerable<string> Path { get; private set; }
    }
}
