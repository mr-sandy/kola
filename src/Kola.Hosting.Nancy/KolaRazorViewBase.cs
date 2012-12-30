using Nancy.ViewEngines.Razor;

namespace Kola.Hosting.Nancy
{
    public abstract class KolaRazorViewBase<T> : NancyRazorViewBase<T>
    {
        public string Greet()
        {
            return "Hi, Nancy!";
        }
    }
}