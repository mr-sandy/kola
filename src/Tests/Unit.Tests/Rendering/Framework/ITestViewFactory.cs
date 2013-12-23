namespace Unit.Tests.Rendering.Framework
{
    internal interface ITestViewFactory
    {
        TestView Create(string viewName);
    }
}