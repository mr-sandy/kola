namespace Unit.Tests.Experimental.Stubs
{
    using System;

    using Kola.Experimental;

    internal class TestKolaResponse : IKolaResponse
    {
        private readonly Func<string> toHtml;

        public TestKolaResponse(Func<string> toHtml)
        {
            this.toHtml = toHtml;
        }

        public string ToHtml()
        {
            return this.toHtml();
        }
    }
}