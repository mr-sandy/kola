namespace Unit.Tests.Experimental.Framework
{
    public interface IViewHelper
    {
        string RenderPartial(string viewName, IComponent component);
    }
}