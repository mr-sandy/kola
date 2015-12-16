namespace Unit.Tests.Domain.ContextSourcedContentResolverTests
{
    using System.Collections.Generic;

    using FluentAssertions;

    using Kola.Domain.Composition.PropertyValues;
    using Kola.Domain.Instances.Context;

    using NUnit.Framework;

    public class WhenResolvingContextSourcedContent
    {
        private string result;

        [SetUp]
        public void SetUp()
        {
            var source = "hello {{name}}. are you a {{animal}}{{non-existent}}? is your name {{{name}}}?";

            var stack = new Stack<ContextSet>();
            stack.Push(new ContextSet(new[] { new ContextItem("name", "banjo"), new ContextItem("animal", "hippo") }));
            stack.Push(new ContextSet(new[] { new ContextItem("name", "sandy") }));

            var sut = new ContextSourcedContentResolver(stack);

            this.result = sut.Resolve(source);
        }

        [Test]
        public void Test()
        {
            this.result.Should().Be("hello sandy. are you a hippo? is your name {sandy}?");
        }
    }
}
