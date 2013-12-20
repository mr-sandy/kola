namespace Unit.Tests.Experimental.Stubs
{
    using System;

    using Kola.Experimental;

    internal class TestAtomView : TestView
    {
        private readonly string html;

        public TestAtomView(string html)
        {
            this.html = html;
        }

        public override IKolaResponse Render<T>(T model)
        {
            return new TestKolaResponse(() => this.html);
        }
    }
}