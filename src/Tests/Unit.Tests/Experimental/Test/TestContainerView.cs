namespace Unit.Tests.Experimental.Test
{
    using System.Text;

    using Unit.Tests.Experimental.Framework;

    internal class TestContainerView : TestView
    {
        private readonly string openingHtml;
        private readonly string closingHtml;

        public TestContainerView(KolaEngine engine, string openingHtml, string closingHtml)
            : base(engine)
        {
            this.openingHtml = openingHtml;
            this.closingHtml = closingHtml;
        }

        public override string Render(IComponent component, IViewHelper viewHelper)
        {
            var sb = new StringBuilder();

            sb.Append(this.openingHtml);

            var children = Engine.Render(component.Children);

            sb.Append(children.ToHtml(viewHelper));

            sb.Append(this.closingHtml);

            return sb.ToString();
        }
    }
}