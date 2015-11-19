namespace Kola.Domain.Composition
{
    public interface IContent
    {
        T Accept<T>(IContentVisitor<T> visitor);
    }
}