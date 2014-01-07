namespace Kola.Rendering
{
    public interface IPageHandler
    {
        IPage GetPage(string templatePath);
    }
}