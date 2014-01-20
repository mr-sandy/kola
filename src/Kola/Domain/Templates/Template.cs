﻿namespace Kola.Domain.Templates
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Kola;
    using Kola.Domain.Instances;
    using Kola.Domain.Templates.Amendments;
    using Kola.Rendering;

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

        public void AddComponent(IComponent component, int index)
        {
            if (index > this.components.Count)
            {
                throw new KolaException("Specified index outwith bounds of component collection");
            }

            this.components.Insert(index, component);
        }

        public void RemoveComponentAt(int index)
        {
            this.components.RemoveAt(index);
        }

        public IAmendment UndoAmendment()
        {
            throw new NotImplementedException();
        }

        public IPage Build(BuildContext buildContext)
        {
            return new Page(this.Components.Select(c => c.Build(buildContext)));
        }
    }
}