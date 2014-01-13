﻿namespace Kola.Domain
{
    using System.Collections.Generic;

    public class WidgetSpecification : IComponentSpecification, IComponentCollection
    {
        private readonly List<IComponent> components = new List<IComponent>();

        public WidgetSpecification(string name, IEnumerable<IComponent> components = null)
        {
            this.Name = name;

            if (components != null)
            {
                this.components.AddRange(components);
            }
        }

        public string Name { get; private set; }

        public IEnumerable<IComponent> Components
        {
            get { return this.components; }
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

        public IComponent Create()
        {
            return new Widget(this.Name);
        }
    }
}