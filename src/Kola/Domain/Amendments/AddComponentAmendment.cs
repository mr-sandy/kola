namespace Kola.Domain.Amendments
{
    using System;
    using System.Collections.Generic;

    using Kola.Domain;

    public class AddComponentAmendment : IAmendment
    {
        public AddComponentAmendment(string componentName, IEnumerable<int> parentPath, int index)
        {
            this.ComponentName = componentName;
            this.ParentPath = parentPath;
            this.Index = index;
        }

        public string ComponentName { get; private set; }

        public IEnumerable<int> ParentPath { get; internal set; }

        public int Index { get; private set; }

        public IEnumerable<int> GetRootComponent()
        {
            return this.ParentPath;
        }

        public void Accept(IAmendmentVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}