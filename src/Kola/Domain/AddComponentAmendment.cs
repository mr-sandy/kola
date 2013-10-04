namespace Kola.Domain
{
    using System.Collections.Generic;

    public class AddComponentAmendment : Amendment
    {
        public AddComponentAmendment(string componentType, IEnumerable<int> componentPath, int index)
        {
            this.ComponentType = componentType;
            this.ComponentPath = componentPath;
            this.Index = index;
        }

        public string ComponentType { get; private set; }

        public IEnumerable<int> ComponentPath { get; private set; }

        public int Index { get; private set; }

        public override void Accept(IAmendmentVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}