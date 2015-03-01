namespace Kola.Domain.Rendering
{
    using System.Collections.Generic;
    using System.Text;

    public class CompositeResult : IResult
    {
        private readonly IEnumerable<IResult> results;

        public CompositeResult(IEnumerable<IResult> results)
        {
            this.results = results;
        }

        public string ToHtml(IViewHelper viewHelper)
        {
            var sb = new StringBuilder();

            foreach (var result in this.results)
            {
                sb.Append(result.ToHtml(viewHelper));
            }

            return sb.ToString();
        }
    }
}