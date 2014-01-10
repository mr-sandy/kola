namespace Kola.Domain
{
    using System;
    using System.Collections.Generic;

    public class Widget : IComponent
    {
        private readonly List<PlaceHolder> placeHolders = new List<PlaceHolder>();

        public Widget(string name, IEnumerable<PlaceHolder> placeHolders = null)
        {
            this.Name = name;

            if (placeHolders != null)
            {
                this.placeHolders.AddRange(placeHolders);
            }
        }

        public string Name { get; private set; }

        public IEnumerable<PlaceHolder> PlaceHolders
        {
            get { return this.placeHolders; }
        }

        public void Accept(IComponentVisitor visitor)
        {
            throw new NotImplementedException();
        }
    }

    public class PlaceHolder : IComponentCollection
    {
        public IEnumerable<IComponent> Components
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public void AddComponent(IComponent component, int index)
        {
            throw new NotImplementedException();
        }

        public void RemoveComponentAt(int index)
        {
            throw new NotImplementedException();
        }
    }
}