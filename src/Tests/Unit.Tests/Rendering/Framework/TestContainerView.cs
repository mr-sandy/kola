namespace Unit.Tests.Rendering.Framework
{
    using System.Text;

    using Kola.Rendering;

    internal class TestContainerView : TestView
    {
        private readonly KolaEngine kolaEngine;
        private readonly string openingHtml;
        private readonly string closingHtml;

        public TestContainerView(KolaEngine kolaEngine, string openingHtml, string closingHtml)
        {
            this.kolaEngine = kolaEngine;
            this.openingHtml = openingHtml;
            this.closingHtml = closingHtml;
        }

        public override string Render<T>(T model, IViewHelper viewHelper)
        {
            var component = model as IComponent;
            var sb = new StringBuilder();

            sb.Append(this.openingHtml);

            var children = this.kolaEngine.Render(component.Children);

            sb.Append(children.ToHtml(viewHelper));

            sb.Append(this.closingHtml);

            return sb.ToString();
        }
    }
}