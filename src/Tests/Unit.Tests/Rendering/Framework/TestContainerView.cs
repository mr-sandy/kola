namespace Unit.Tests.Rendering.Framework
{
    using System.Text;

    using Kola.Domain.Instances;
    using Kola.Domain.Rendering;

    internal class TestContainerView : TestView
    {
        private readonly Renderer renderer;
        private readonly string openingHtml;
        private readonly string closingHtml;

        public TestContainerView(Renderer renderer, string openingHtml, string closingHtml)
        {
            this.renderer = renderer;
            this.openingHtml = openingHtml;
            this.closingHtml = closingHtml;
        }

        public override string Render<T>(T model, IViewHelper viewHelper)
        {
            var component = model as ContainerInstance;
            var sb = new StringBuilder();

            sb.Append(this.openingHtml);

            var children = this.renderer.Render(component.Components);

            sb.Append(children.ToHtml(viewHelper));

            sb.Append(this.closingHtml);

            return sb.ToString();
        }
    }
}