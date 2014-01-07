namespace Kola.Processing
{
    public interface IPageHandler
    {
        IPage GetPage(string templatePath);
    }
}