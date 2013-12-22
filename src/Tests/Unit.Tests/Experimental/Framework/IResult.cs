namespace Unit.Tests.Experimental.Framework
{
    using System;

    public interface IResult
    {
        string ToHtml(IViewHelper viewHelper);
    }

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
