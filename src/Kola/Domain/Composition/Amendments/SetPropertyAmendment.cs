namespace Kola.Domain.Composition.Amendments
{
    using System;
    using System.Collections.Generic;

    using Kola.Extensions;

    public class SetPropertyAmendment : IAmendment
    {
        public SetPropertyAmendment(IEnumerable<int> componentPath, string propertyName, string value)
        {
            this.ComponentPath = componentPath;
            this.PropertyName = propertyName;
            this.Value = value;
        }

        public IEnumerable<int> ComponentPath { get; private set; }

        public string PropertyName { get; private set; }

        public string Value { get; private set; }

        public IEnumerable<IEnumerable<int>> SubjectPaths
        {
            get { yield return this.ComponentPath; }
        }

        public void Accept(IAmendmentVisitor visitor)
        {
            throw new NotImplementedException();
        }

        public T Accept<T>(IAmendmentVisitor<T> visitor)
        {
            throw new NotImplementedException();
        }

        public T Accept<T, TContext>(IAmendmentVisitor<T, TContext> visitor, TContext context)
        {
            throw new NotImplementedException();
        }
    }
}