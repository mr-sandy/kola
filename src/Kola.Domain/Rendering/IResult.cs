namespace Kola.Domain.Rendering
{
    public interface IResult
    {
        string ToHtml(IViewHelper viewHelper);
    }
}
