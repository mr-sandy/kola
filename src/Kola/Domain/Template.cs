using System;
using System.Collections.Generic;

namespace Kola.Domain
{
    public class Template : ComponentContainer
    {
        public Template(IEnumerable<string> path)
        {
            this.Path = path;
        }

        public IEnumerable<string> Path { get; private set; }
    }

    public class Atom : IComponent
    {
        public string Name
        {
            get { throw new NotImplementedException(); }
        }
    }
}
