namespace Kola.Domain.Rendering
{
    using System.Linq;
    using System.Xml.Linq;

    public class AnnotatedResult : IResult
    {
        private readonly string path;

        private readonly IResult innerResult;

        public AnnotatedResult(string path, IResult innerResult)
        {
            this.path = path;
            this.innerResult = innerResult;
        }

        // TODO This is a real mess
        public string ToHtml(IViewHelper viewHelper)
        {
            var result = this.innerResult.ToHtml(viewHelper);

            var el = XElement.Parse("<fake>" + result + "</fake>");

            foreach (var decendant in el.Elements().Where(d => d.Attribute("componentPath") == null))
            {
                decendant.SetAttributeValue("componentPath", this.path);
            }

            var reader = el.CreateReader();
            reader.MoveToContent();
            return reader.ReadInnerXml();
            //return el.Elements().Aggregate(string.Empty, (html, xel) => html + xel.ToString());
        }
    }
}