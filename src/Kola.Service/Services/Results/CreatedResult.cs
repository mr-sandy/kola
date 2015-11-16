namespace Kola.Service.Services.Results
{
    public class CreatedResult<T> : IResult<T>
    {
        public CreatedResult(T data)
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