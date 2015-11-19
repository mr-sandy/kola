namespace Kola.Domain.Composition
{
    public class Redirect : IContent
    {
        public Redirect(string location)
        {
            this.Location = location;
        }

        public string Location { get; }

        public T Accept<T>(IContentVisitor<T> visitor)
        {
            return visitor.Visit(this);
        }
    }
}