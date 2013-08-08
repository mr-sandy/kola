using Nancy.ViewEngines.Razor;

namespace Kola.ViewEngines.Razor
{
    public abstract class KolaRazorViewBase<TModel> : NancyRazorViewBase<TModel>
    {
        protected KolaRazorViewBase()
        {
            this.KolaHtmlHelper = new KolaHtmlHelper();
        }

        public KolaHtmlHelper KolaHtmlHelper { get; private set; }
    }

    public class KolaHtmlHelper
    {
        
    }
}