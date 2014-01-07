namespace Unit.Tests.Rendering.Framework
{
    using Kola.Rendering;

    internal class TestAtomView : TestView
    {
        private readonly string html;

        public TestAtomView(string html)
        {
            this.html = html;
        }

        public override string Render<T>(T model, IViewHelper viewHelper)
        {
            return this.html;
        }
    }
}