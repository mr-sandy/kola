namespace Kola.Domain.Composition.Amendments
{
    using System.Collections.Generic;

    using Kola.Domain.Extensions;

    public class MoveComponentAmendment : IAmendment
    {
        public MoveComponentAmendment(IEnumerable<int> sourcePath, IEnumerable<int> targetPath)
        {
            this.TargetPath = targetPath;
            this.SourcePath = sourcePath;
        }

        public IEnumerable<int> TargetPath { get; private set; }

        public IEnumerable<int> SourcePath { get; private set; }

        public IEnumerable<IEnumerable<int>> SubjectPaths
        {
            // TODO This needs to return an array of paths to handle moves
            // Will need to consolidate to/from paths into a single path when appropriate
            get { return this.SourcePath.TakeAllButLast().Consolidate(this.TargetPath.TakeAllButLast()); }
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