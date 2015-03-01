namespace Kola.Domain.Rendering
{
    public class EmptyResult : IResult
    {
        public string ToHtml(IViewHelper viewHelper)
        {
            return string.Empty;
        }
    }
}