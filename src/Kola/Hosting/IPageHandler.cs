
namespace Kola.Hosting
{
    public interface IPageHandler
    {
        string GetPage(string path);
    }

    public class PageHandler : IPageHandler
    {
        public string GetPage(string path)
        {
            return "Page";
        }
    }
}
