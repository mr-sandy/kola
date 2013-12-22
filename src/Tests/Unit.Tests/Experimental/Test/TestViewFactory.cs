namespace Unit.Tests.Experimental.Test
{
    using Unit.Tests.Experimental.Framework;

    internal interface ITestViewFactory
    {
        TestView Create(string viewName);
    }

    internal class TestViewFactory : ITestViewFactory
    {
        private readonly KolaEngine kolaEngine;

        public TestViewFactory(KolaEngine kolaEngine)
        {
            this.kolaEngine = kolaEngine;
        }

        public TestView Create(string viewName)
        {
            if (viewName.Contains("atom"))
            {
                return new TestAtomView(this.kolaEngine, string.Format("<{0}/>", viewName));
            }

            if (viewName.Contains("container"))
            {
                return new TestContainerView(this.kolaEngine, string.Format("<{0}>", viewName), string.Format("</{0}>", viewName));
            }

            return null;
        }
    }
}