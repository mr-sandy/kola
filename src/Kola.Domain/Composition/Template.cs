namespace Kola.Domain.Composition
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

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

        public IEnumerable<string> InstancePaths { get; private set; }

        public void BuildInstancePaths(IPathInstanceBuilder pathInstanceBuilder)
        {
            this.InstancePaths = pathInstanceBuilder.Build(this.Path);
        }

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