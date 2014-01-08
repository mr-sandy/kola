namespace Unit.Tests.Domain.Fake
{
    using System.Collections.Generic;

    using Kola;

    public class Template : IComponentCollection
    {
        private readonly List<IAmendment> amendments = new List<IAmendment>();
        private readonly List<IComponent> components = new List<IComponent>();

        public Template(IEnumerable<IComponent> components = null, IEnumerable<IAmendment> amendments = null)
        {
            if (components != null)
            {
                this.components.AddRange(components);
            }

            if (amendments != null)
            {
                this.amendments.AddRange(amendments);
            }
        }

        public IEnumerable<IAmendment> Amendments
        {
            get { return this.amendments; }
        }

        public IEnumerable<IComponent> Components
        {
            get { return this.components; }
        }

        public void AddAmendment(IAmendment amendment)
        {
            this.amendments.Add(amendment);
        }

        public void ApplyAmendments(IComponentFactory componentFactory)
        {
            var visitor = new AmendmentApplyingVisitor(this, componentFactory);

            foreach (var amendment in this.amendments)
            {
                amendment.Accept(visitor);
            }
        }

        public void AddComponent(IComponent component, int index)
        {
            if (index > this.components.Count)
            {
                throw new KolaException("Specified index outwith bounds of component collection");
            }

            this.components.Insert(index, component);
        }
    }
}