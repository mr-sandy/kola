namespace Kola.Domain
{
    using System.Collections.Generic;

    public class Template : Composite
    {
        public Template(IEnumerable<string> path)
        {
            this.Path = path;
        }

        public IEnumerable<string> Path { get; private set; }

        public void AddAmendment(Amendment amendment)
        {

        }
    }
}