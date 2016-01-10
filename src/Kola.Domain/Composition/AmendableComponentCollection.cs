namespace Kola.Domain.Composition
{
    using System.Collections.Generic;
    using System.Linq;

    using Kola.Domain.Composition.Amendments;

    public abstract class AmendableComponentCollection : IComponentCollection
    {
        private readonly List<IAmendment> amendments = new List<IAmendment>();
        
        private readonly List<IComponent> components = new List<IComponent>();

        protected AmendableComponentCollection(IEnumerable<IComponent> components, IEnumerable<IAmendment> amendments)
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

        public IEnumerable<IAmendment> Amendments => this.amendments;

        public IEnumerable<IComponent> Components => this.components;

        public void AddAmendment(IAmendment amendment)
        {
            this.amendments.Add(amendment);
        }

        public void ApplyAmendments(IComponentSpecificationLibrary componentLibrary, bool reset = false)
        {
            var visitor = new AmendmentApplyingVisitor(this, componentLibrary);

            foreach (var amendment in this.amendments)
            {
                amendment.Accept(visitor);
            }

            if (reset)
            {
                this.amendments.Clear();
            }
        }

        public void Insert(int index, IComponent component)
        {
            if (index > this.components.Count)
            {
                throw new KolaException("Specified index outwith bounds of component collection");
            }

            this.components.Insert(index, component);
        }

        public void RemoveAt(int index)
        {
            this.components.RemoveAt(index);
        }

        public IAmendment UndoAmendment()
        {
            if (this.amendments.Any())
            {
                var amendment = this.amendments.Last();
                this.amendments.Remove(amendment);
                return amendment;
            }

            return null;
        }

        public abstract T Accept<T>(IAmendableComponentCollectionVisitor<T> visitor);
    }
}