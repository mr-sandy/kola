namespace Unit.Tests.Domain.Fake
{
    using System.Collections.Generic;

    using Kola;

    public class Container : IComponent, IComponentCollection
    {
        private readonly List<IComponent> components = new List<IComponent>();

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
    }
}