namespace Kola.Processing
{
    using System;

    public class Result : IResult
    {
        private readonly Func<IViewHelper, string> value;

        public Result(Func<IViewHelper, string> value)
        {
            this.value = value;
        }

        public string ToHtml(IViewHelper viewHelper)
        {
            return this.value(viewHelper);
        }
    }
}