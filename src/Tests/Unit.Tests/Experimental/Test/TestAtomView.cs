namespace Unit.Tests.Experimental.Test
{
    using Unit.Tests.Experimental.Framework;

    internal class TestAtomView : TestView
    {
        private readonly string html;

        public TestAtomView(KolaEngine engine, string html)
            : base(engine)
        {
            this.html = html;
        }

        public override string Render(IComponent component, IViewHelper viewHelper)
        {
            return this.html;
        }
    }
}