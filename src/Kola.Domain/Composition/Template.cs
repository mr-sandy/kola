namespace Kola.Domain.Composition
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Kola;
    using Kola.Domain.Composition.Amendments;
    using Kola.Domain.Instances;
    using Kola.Domain.Instances.Context;
    using Kola.Domain.Rendering;

    public class Template : IComponentCollection
    {
        private readonly List<IAmendment> amendments = new List<IAmendment>();
        private readonly List<IComponent> components = new List<IComponent>();

        public Template(IEnumerable<string> path, IEnumerable<IComponent> components = null, IEnumerable<IAmendment> amendments = null)
        {
            this.Path = path;

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

        public IEnumerable<string> Path { get; private set; }

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

        public void UndoAmendment()
        {
            if (this.amendments.Any())
            {
                this.amendments.RemoveAt(this.amendments.Count() - 1);
            }
        }

        public PageInstance Build(IBuilder builder, IBuildContext buildContext)
        {
            return builder.Build(this, buildContext);
        }
    }
}