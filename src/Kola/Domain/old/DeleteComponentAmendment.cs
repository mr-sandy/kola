namespace Kola.Domain
{
    using System.Collections.Generic;

    using Kola.Extensions;

    public class DeleteComponentAmendment : Amendment
    {
        public DeleteComponentAmendment(IEnumerable<int> componentPath)
        {
            this.ComponentPath = componentPath;
        }

        public IEnumerable<int> ComponentPath { get; private set; }

        public override void Accept(IAmendmentVisitor visitor)
        {
            visitor.Visit(this);
        }

        public override IEnumerable<int> GetRootComponent()
        {
            return this.ComponentPath.TakeAllButLast();
        }
    }
}