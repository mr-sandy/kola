using System;
using System.Collections.Generic;

namespace Kola.Domain
{
    public abstract class ComponentContainer : IComponent
    {
        private readonly List<IComponent> components = new List<IComponent>();

        public string Name
        {
            get { throw new NotImplementedException(); }
        }

        public IEnumerable<IComponent> Components { get { return this.components; } }

        public void AddChild(IComponent component, int index)
        {
            
        }
    }
}