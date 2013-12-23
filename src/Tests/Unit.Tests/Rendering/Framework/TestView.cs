namespace Unit.Tests.Rendering.Framework
{
    using Kola.Processing;

    internal abstract class TestView
    {
        public abstract string Render<T>(T model, IViewHelper viewHelper);
    }
}