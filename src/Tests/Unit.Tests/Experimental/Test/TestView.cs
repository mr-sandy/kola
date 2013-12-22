namespace Unit.Tests.Experimental.Test
{
    using Unit.Tests.Experimental.Framework;

    internal abstract class TestView
    {
        protected readonly KolaEngine Engine;

        protected TestView(KolaEngine engine)
        {
            this.Engine = engine;
        }

        public abstract string Render(IComponent component, IViewHelper viewHelper);
    }
}