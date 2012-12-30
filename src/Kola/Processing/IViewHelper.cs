namespace Kola.Processing
{
    public interface IViewHelper
    {
        string RenderPartial<T>(string viewName, T model);
    }
}