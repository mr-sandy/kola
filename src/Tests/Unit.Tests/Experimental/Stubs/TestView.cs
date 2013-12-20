namespace Unit.Tests.Experimental.Stubs
{
    using Kola.Experimental;

    internal abstract class TestView
    {
        public abstract IKolaResponse Render<T>(T model);
    }
}