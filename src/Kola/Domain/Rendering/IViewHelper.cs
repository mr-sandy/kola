namespace Kola.Domain.Rendering
{
    public interface IViewHelper
    {
        string RenderPartial<T>(string viewName, T model);
    }
}