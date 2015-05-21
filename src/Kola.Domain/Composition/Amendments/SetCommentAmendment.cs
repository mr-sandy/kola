namespace Kola.Domain.Composition.Amendments
{
    using System.Collections.Generic;

    public class SetCommentAmendment : IAmendment
    {
        public SetCommentAmendment(IEnumerable<int> componentPath, string comment)
        {
            this.ComponentPath = componentPath;
            this.Comment = comment;
        }

        public IEnumerable<int> ComponentPath { get; private set; }

        public string Comment { get; private set; }

        public IEnumerable<IEnumerable<int>> AffectedPaths
        {
            get { yield return this.ComponentPath; }
        }

        public IEnumerable<int> SubjectPath
        {
            get { return this.ComponentPath; }
        }

        public void Accept(IAmendmentVisitor visitor)
        {
            visitor.Visit(this);
        }

        public T Accept<T>(IAmendmentVisitor<T> visitor)
        {
            return visitor.Visit(this);
        }

        public T Accept<T, TContext>(IAmendmentVisitor<T, TContext> visitor, TContext context)
        {
            return visitor.Visit(this, context);
        }
    }
}