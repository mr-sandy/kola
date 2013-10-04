namespace Kola.Domain
{
    using System.Collections.Generic;

    public class Template : Composite
    {
        private readonly List<Amendment> amendments = new List<Amendment>();

        public Template(IEnumerable<string> path)
        {
            this.Path = path;
        }

        public IEnumerable<string> Path { get; private set; }

        public IEnumerable<Amendment> Amendments
        {
            get { return this.amendments; }
        }

        public void AddAmendment(Amendment amendment)
        {
            this.amendments.Add(amendment);
        }
    }
}