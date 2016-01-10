namespace Kola.Domain.Composition
{
    using System.Collections.Generic;

    using Kola.Domain.Composition.Amendments;

    public class Template : AmendableComponentCollection, IContent
    {
        public Template(IEnumerable<string> path, 
            IEnumerable<IComponent> components = null, 
            IEnumerable<IAmendment> amendments = null) 
            : base(components, amendments)
        {
            this.Path = path;
        }

        public IEnumerable<string> Path { get; private set; }

        public T Accept<T>(IContentVisitor<T> visitor)
        {
            return visitor.Visit(this);
        }

        public override T Accept<T>(IAmendableComponentCollectionVisitor<T> visitor)
        {
            return visitor.Visit(this);
        }
    }
}