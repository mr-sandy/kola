namespace Kola.Service.Services.Results
{
    public class MovedPermanentlyResult<T> : IResult<T>
    {
        public MovedPermanentlyResult(string location)
        {
            this.Location = location;
        }

        public string Location { get; }

        public TV Accept<TV>(IResultVisitor<T, TV> visitor)
        {
            return visitor.Visit(this);
        }
    }
}