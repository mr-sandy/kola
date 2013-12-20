namespace Unit.Tests.Experimental.Framework
{
    using System;

    internal class AtomView : View<IComponent>
    {
        private readonly string html;

        public AtomView(IViewHelper viewHelper, string html)
            : base(viewHelper)
        {
            this.html = html;
        }

        public override string Render(IComponent model)
        {
            return this.html;
        }
    }
}