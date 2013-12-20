namespace Unit.Tests.Experimental.Framework
{
    using System;

    internal class PageView : View<IPage>
    {
        public PageView(IViewHelper viewHelper)
            : base(viewHelper)
        {
        }

        public override string Render(IPage model)
        {
            return "jam";
        }
    }
}