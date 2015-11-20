namespace Persistence.Tests.ContentFinderTests.FakeSources
{
    using System;
    using System.Collections.Generic;

    using Kola.Domain.DynamicSources;
    using Kola.Domain.Instances.Context;
    using Kola.Persistence;

    internal class TestSource : IDynamicSource
    {
        public SourceLookupResponse Lookup(string value, IEnumerable<IContextItem> context)
        {
            return this.Func(value, context);
        }

        public Func<string, IEnumerable<IContextItem>, SourceLookupResponse> Func { get; set; }
    }
}
