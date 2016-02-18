namespace Kola.Service.Services.Results
{
    public class ForbiddenResult<T> : IResult<T>
    {
        public ForbiddenResult(T data = default(T))
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