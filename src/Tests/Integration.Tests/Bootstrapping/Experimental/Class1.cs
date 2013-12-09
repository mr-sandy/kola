namespace Integration.Tests.Bootstrapping.Experimental
{
    // Is it possible to use injection to write an integration test that generates the html for a whole page?
    public class KolaRenderer
    {
        public IResponse RenderPage(Kola.Domain.Page page)
        {
            
        }
    }

    public interface IResponse
    {
        string ToHtml();
    }

}
