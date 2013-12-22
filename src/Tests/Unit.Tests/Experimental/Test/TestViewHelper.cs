namespace Unit.Tests.Experimental.Test
{
    using Unit.Tests.Experimental.Framework;

    internal class TestViewHelper : IViewHelper
    {
        private readonly ITestViewFactory viewFactory;

        public TestViewHelper(ITestViewFactory viewFactory)
        {
            this.viewFactory = viewFactory;
        }

        public string RenderPartial(string viewName, IComponent component)
        {
            var view = this.viewFactory.Create(viewName);
            return view.Render(component, this);
        }
    }
}