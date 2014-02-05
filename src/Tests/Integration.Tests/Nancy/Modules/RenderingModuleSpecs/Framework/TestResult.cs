namespace Integration.Tests.Nancy.Modules.RenderingModuleSpecs.Framework
{
    using Kola.Domain.Rendering;

    public class TestResult : IResult
    {
        private readonly string html;

        public TestResult(string html)
        {
            this.html = html;
        }

        public string ToHtml(IViewHelper viewHelper)
        {
            return this.html;
        }
    }
}