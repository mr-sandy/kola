namespace Unit.Tests.Experimental.Stubs
{
    using System;

    using Kola.Experimental;

    internal class TestContainerView : TestView
    {
        private readonly string startHtml;
        private readonly string endHtml;

        public TestContainerView(string startHtml, string endHtml)
        {
            this.startHtml = startHtml;
            this.endHtml = endHtml;
        }

        public override IKolaResponse Render<T>(T model)
        {
            Func<string> toHtml = () => this.startHtml + this.endHtml;

            return new TestKolaResponse(toHtml);
        }
    }
}