namespace Kola.Domain
{
    using System;

    public class SimpleComponent : Component
    {
        public SimpleComponent(string name) : base(name)
        {
        }

        public override void Accept(IComponentVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}