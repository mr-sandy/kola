namespace Unit.Tests.Experimental
{
    // Is it possible to use injection to write an integration test that generates the html for a whole page?
    public class KolaRenderer
    {
        public IResponse Render(IPage page)
        {
            return null;
        }
    }

    public interface IResponse
    {
        string ToHtml();
    }

    public interface IHandler
    {
        IResponse Render(IComponent component, IViewHelper viewHelper);
    }

    public class DefaultHandler : IHandler
    {
        public IResponse Render(IComponent component, IViewHelper viewHelper)
        {
            return viewHelper.RenderPartial(component.Name, component);
        }
    }

    public interface IComponent
    {
        string Name { get; }
    }

    public interface IPage
    {
        
    }

    public interface IViewHelper
    {
        IResponse RenderPartial<T>(string viewName, T model);
    }
}
