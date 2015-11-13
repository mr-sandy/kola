namespace Kola.Service.Services.Results
{
    public class FailureResult<T> : IResult<T>
    {
        public FailureResult(string message = "")
        {
            this.Message = message;
        }

        public string Message { get; private set; }

        public TV Accept<TV>(IResultVisitor<T, TV> visitor)
        {
            return visitor.Visit(this);
        }
    }
}