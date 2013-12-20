namespace Unit.Tests.Experimental.Stubs
{
    using System.Collections.Generic;

    using Kola.Experimental;

    internal class TestViewHelper : IViewHelper
    {
        private readonly IDictionary<string, TestView> views;

        public TestViewHelper(IDictionary<string, TestView> views)
        {
            this.views = views;
        }

        public IKolaResponse RenderPartial<T>(string viewName, T model)
        {
            return this.views[viewName].Render(model);
        }
    }
}