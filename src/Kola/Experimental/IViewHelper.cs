namespace Kola.Experimental
{
    public interface IViewHelper
    {
        IKolaResponse RenderPartial<T>(string viewName, T model);
    }
}