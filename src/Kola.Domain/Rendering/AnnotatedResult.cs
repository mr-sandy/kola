namespace Kola.Domain.Rendering
{
    using System.Collections.Generic;

    using Kola.Domain.Extensions;

    public class AnnotatedResult : IResult
    {
        private readonly IResult innerResult;

        private readonly IEnumerable<int> path;

        public AnnotatedResult(IResult innerResult, IEnumerable<int> path)
        {
            this.innerResult = innerResult;
            this.path = path;
        }

        public string ToHtml(IViewHelper viewHelper)
        {
            var result = this.innerResult.ToHtml(viewHelper);

            return (this.path == null)
                ? result 
                : string.Format("<!--{0}-start-->{1}<!--{0}-end-->", this.path.ToHttpPath(), result);
        }
    }
}