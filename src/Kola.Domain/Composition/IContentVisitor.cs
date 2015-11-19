namespace Kola.Domain.Composition
{
    public interface IContentVisitor<out T>
    {
        T Visit(Redirect redirect);

        T Visit(Template template);
    }
}