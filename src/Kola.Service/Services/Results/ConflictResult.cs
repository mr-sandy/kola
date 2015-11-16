namespace Kola.Service.Services.Results
{
    public class ConflictResult<T> : IResult<T>
    {
        public TV Accept<TV>(IResultVisitor<T, TV> visitor)
        {
            return visitor.Visit(this);
        }
    }
}