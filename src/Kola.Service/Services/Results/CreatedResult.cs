namespace Kola.Service.Services.Results
{
    using System.Collections.Generic;

    public class CreatedResult<T> : IResult<T>
    {
        public CreatedResult(T data, IEnumerable<string> path)
        {
            this.Data = data;
            this.Path = path;
        }

        public T Data { get; set; }

        public IEnumerable<string> Path { get; set; }

        public TV Accept<TV>(IResultVisitor<T, TV> visitor)
        {
            return visitor.Visit(this);
        }
    }
}