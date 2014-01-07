namespace Kola.Editing.Amendments
{
    using System.Collections.Generic;

    public abstract class Amendment
    {
        public abstract void Accept(IAmendmentVisitor visitor);

        public abstract IEnumerable<int> GetRootComponent();
    }
}