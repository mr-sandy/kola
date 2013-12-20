namespace Kola.Experimental
{
    public class DefaultHandler : IKolaHandler
    {
        public IKolaResponse Render(IKolaComponent component, IViewHelper viewHelper)
        {
            return viewHelper.RenderPartial(component.Name, component);
        }
    }
}