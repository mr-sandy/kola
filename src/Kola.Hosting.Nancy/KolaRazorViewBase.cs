using Nancy.ViewEngines.Razor;

namespace Kola.Hosting.Nancy
{
    public abstract class KolaRazorViewBase<T> : NancyRazorViewBase<T>
    {
        protected KolaRazorViewBase()
        {
            this.KolaHtmlHelper = new KolaHtmlHelper();
        }

        public string Greet()
        {
            return "From view base";
        }

        public KolaHtmlHelper KolaHtmlHelper { get; private set; }
    }

    public class KolaHtmlHelper
    {
        
    }
}