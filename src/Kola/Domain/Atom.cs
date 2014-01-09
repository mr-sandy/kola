namespace Kola.Domain
{
    using System;

    public class Atom : IComponent
    {
        public Atom(string name)
        {
            this.Name = name;
        }

        public string Name { get; private set; }

        public void Accept(IComponentVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}