namespace Kola.Service.Services.Results
{
    public class SuccessResult<T> : IResult<T>
    {
        public SuccessResult(T data)
        {
            this.Data = data;
        }

        public T Data { get; set; }

        public TV Accept<TV>(IResultVisitor<T, TV> visitor)
        {
            return visitor.Visit(this);
        }
    }
}