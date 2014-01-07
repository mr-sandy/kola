namespace Unit.Tests.Rendering.Framework
{
    using Kola.Rendering;

    internal abstract class TestView
    {
        public abstract string Render<T>(T model, IViewHelper viewHelper);
    }
}