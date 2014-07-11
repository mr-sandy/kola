namespace Unit.Tests.Rendering.Framework
{
    using Kola.Domain.Rendering;

    internal class TestViewFactory : ITestViewFactory
    {
        private readonly MultiRenderer renderer;

        public TestViewFactory(MultiRenderer renderer)
        {
            this.renderer = renderer;
        }

        public TestView Create(string viewName)
        {
            if (viewName.Contains("atom"))
            {
                return new TestAtomView(string.Format("<{0}/>", viewName));
            }

            if (viewName.Contains("container"))
            {
                return new TestContainerView(this.renderer, string.Format("<{0}>", viewName), string.Format("</{0}>", viewName));
            }

            return null;
        }
    }
}