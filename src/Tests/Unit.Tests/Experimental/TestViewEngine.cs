namespace Unit.Tests.Experimental
{
    using System;

    using Kola.Experimental;

    internal class TestViewEngine
    {
        private readonly IViewHelper viewHelper;

        public TestViewEngine(IViewHelper viewHelper)
        {
            this.viewHelper = viewHelper;
        }

        public IKolaResponse Render(IKolaComponent outerComponent)
        {
            return this.viewHelper.RenderPartial(outerComponent.Name, outerComponent);
        }
    }
}