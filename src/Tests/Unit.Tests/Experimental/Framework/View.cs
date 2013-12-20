namespace Unit.Tests.Experimental.Framework
{
    internal abstract class View<T>
    {
        protected readonly IViewHelper ViewHelper;

        protected View(IViewHelper viewHelper)
        {
            this.ViewHelper = viewHelper;
        }

        public abstract string Render(T model);
    }
}