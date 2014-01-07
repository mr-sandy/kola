namespace Kola.Editing
{
    using System.Collections.Generic;
    using System.Linq;

    using Kola.Editing.Amendments;
    using Kola.Nancy.Modules;

    public class Template : CompositeComponent
    {
        private readonly List<Amendment> amendments = new List<Amendment>();

        public Template(IEnumerable<string> path, IEnumerable<Amendment> amendments = null, IEnumerable<Component> components = null)
            : base(string.Empty, components)
        {
            this.Path = path;

            if (amendments != null)
            {
                this.amendments.AddRange(amendments);
            }
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

        public void ApplyAmendments(IComponentFactory componentFactory, bool reset = false)
        {
            var processor = new AmendmentProcessingVisitor(this, componentFactory);

            foreach (var amendment in this.Amendments)
            {
                amendment.Accept(processor);
            }

            if (reset)
            {
                this.amendments.Clear();
            }
        }

        public void RemoveAmendment(Amendment amendment)
        {
            this.amendments.Remove(amendment);
        }

        public Amendment UndoAmendment()
        {
            if (this.amendments.Count > 0)
            {
                var lastAmendment = this.amendments.Last();
                this.amendments.Remove(lastAmendment);
                return lastAmendment;
            }

            return null;
        }
    }
}