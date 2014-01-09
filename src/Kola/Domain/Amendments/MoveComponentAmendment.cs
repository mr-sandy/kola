namespace Kola.Domain.Amendments
{
    using System;
    using System.Collections.Generic;

    using Kola.Extensions;

    public class MoveComponentAmendment : IAmendment
    {
        public MoveComponentAmendment(IEnumerable<int> sourcePath, IEnumerable<int> targetPath)
        {
            this.TargetPath = targetPath;
            this.SourcePath = sourcePath;
        }

        public IEnumerable<int> TargetPath { get; private set; }

        public IEnumerable<int> SourcePath { get; private set; }

        public void Accept(IAmendmentVisitor visitor)
        {
            visitor.Visit(this);
        }

        public IEnumerable<int> GetRootComponent()
        {
            return this.SourcePath.GetOverlap(this.TargetPath);
        }
    }
}