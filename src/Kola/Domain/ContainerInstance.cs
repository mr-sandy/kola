﻿namespace Kola.Domain
{
    using System.Collections.Generic;

    public class ContainerInstance : IComponentInstance
    {
        public ContainerInstance(string name, IEnumerable<IComponentInstance> children = null)
        {
            this.Name = name;
            this.Children = children;
        }

        public string Name { get; private set; }

        public IEnumerable<IComponentInstance> Children { get; private set; }

        public T Accept<T>(IComponentInstanceVisitor<T> visitor)
        {
            return visitor.Visit(this);
        }
    }
}