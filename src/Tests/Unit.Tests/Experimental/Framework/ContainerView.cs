namespace Unit.Tests.Experimental.Framework
{
    using System;

    internal class ContainerView : View<IComponent>
    {
        public ContainerView(IViewHelper viewHelper)
            : base(viewHelper)
        {
        }

        public override string Render(IComponent model)
        {
            throw new NotImplementedException();
        }
    }
}