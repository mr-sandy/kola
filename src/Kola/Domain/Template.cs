namespace Kola.Domain
{
    using System;
    using System.Collections.Generic;

    public class Template : ComponentContainer
    {
        public Template(IEnumerable<string> path)
        {
            this.Path = path;
        }

        public IEnumerable<string> Path { get; private set; }
    }
}
